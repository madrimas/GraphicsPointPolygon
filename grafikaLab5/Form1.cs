using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafikaLab5
{
    public partial class Form1 : Form
    {
        Graphics drawArea;
        public Form1()
        {
            InitializeComponent();
            drawArea = pictureBox1.CreateGraphics();
        }

        private float Det(float x, float y)
        {
            float det;
            det = 5000 + x + 5000 * y - 5000 - y - 5000 * x;
            return det;
        }
        private float Det2(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            float det = x1 * y2 + y1 * x3 + x2 * y3 - y1 * x2 - x1 * y3 - y2 * x3;
            return det;
        }

        private int Sign(float a)
        {
            if (a > 0) return 1;
            else if (a == 0) return 0;
            else return -1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            drawArea.Clear(Color.Black);
            drawArea.DrawLine(new Pen(Color.Green), 0, 0, 5000, 5000);
            float x = (float)Double.Parse(textBox1.Text);
            float y = (float)Double.Parse(textBox2.Text);
            drawArea.FillEllipse(new SolidBrush(Color.White), x, y, 3, 3);
            if (Det(x, y) > 0)
            {
                label3.Text = "Punkt lezy po lewej stronie!";
            }
            else if (Det(x, y) == 0)
            {
                label3.Text = "Punkt lezy na prostej!";
            }
            else
            {
                label3.Text = "Punkt lezy po prawej stronie!";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            drawArea.Clear(Color.Black);
            drawArea.DrawLine(new Pen(Color.Green), 1, 1, 5000, 5000);
            float x1 = (float)Double.Parse(textBox3.Text);
            float y1 = (float)Double.Parse(textBox4.Text);
            float x2 = (float)Double.Parse(textBox5.Text);
            float y2 = (float)Double.Parse(textBox6.Text);
            drawArea.FillEllipse(new SolidBrush(Color.White), x1, y1, 3, 3);
            drawArea.FillEllipse(new SolidBrush(Color.White), x2, y2, 3, 3);
            if ((Det(x1, y1) < 0 && Det(x2, y2) < 0) || (Det(x1, y1) == 0 && Det(x2, y2) == 0) || (Det(x1, y1) > 0 && Det(x2, y2) > 0))
            {
                label8.Text = "Punkty leza po tej samej stronie";
            }
            else
            {
                label8.Text = "Punkty nie leza po tej samej stronie";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            drawArea.Clear(Color.Black);
            drawArea.DrawLine(new Pen(Color.Green), 1, 1, 5000, 5000);
            float x = (float)Double.Parse(textBox7.Text);
            float y = (float)Double.Parse(textBox8.Text);
            drawArea.FillEllipse(new SolidBrush(Color.White), x, y, 3, 3);
            if (Det(x, y) == 0)
            {
                label11.Text = "Punkt lezy na odcinku!";
            }
            else
            {
                label11.Text = "Punkt nie lezy na odcinku!";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            drawArea.Clear(Color.Black);
            drawArea.DrawLine(new Pen(Color.Green), 1, 1, 5000, 5000);
            float x1 = (float)Double.Parse(textBox9.Text);
            float y1 = (float)Double.Parse(textBox10.Text);
            float x2 = (float)Double.Parse(textBox11.Text);
            float y2 = (float)Double.Parse(textBox12.Text);
            int boolean = 0;
            drawArea.DrawLine(new Pen(Color.Yellow), x1, y1, x2, y2);
            if( Sign(Det(x1, y1)) != Sign(Det(x2, y2)) && Sign(Det2(x1, y1, x2, y2, 1, 1)) != Sign(Det2(x1, y1, x2, y2, 5000, 5000)) )
            {
                boolean = 1;
            }
            else if( Sign(Det2(1, 1, 5000, 5000, x1, y1)) == 0 && ((1 < x1 && x1 < 5000) && (1 < y1 && y1 < 5000)))
            {
                boolean = 1;
            }
            else if( Sign(Det2(1, 1, 5000, 5000, x2, y2)) == 0 && ((1 < x2 && x2 < 5000) && (1 < y2 && y2 < 5000)) )
            {
                boolean = 1;
            }
            else if( Sign(Det2(x1, y1, x2, y2, 1, 1)) == 0 && ((x1 < 1 && 1 < x2) && (y1 < 1 && 1 < y2)) )
            {
                boolean = 1;
            }
            else if( Sign(Det2(x1, y1, x2, y2, 5000, 5000)) == 0 && ((x1 < 5000 && 5000 < x2) && (y1 < 5000 && 5000 < y2)) )
            {
                boolean = 1;
            }
            else
            {
                boolean = 0;
            }

            if( boolean == 1)
            {
                label16.Text = "Odcinki sie przecinaja!";
            }
            else
            {
                label16.Text = "Odcinki sie nie przecinaja!";
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            drawArea.Clear(Color.Black);
            float x1 = (float)Double.Parse(textBox13.Text);
            float y1 = (float)Double.Parse(textBox14.Text);
            float x2 = 5000;
            float y2 = 5000;
            drawArea.DrawLine(new Pen(Color.Aqua), x1, y1, x2, y2);
            PointF[] tab = new PointF[8];
            tab[0] = new PointF(50, 200);
            tab[1] = new PointF(70, 220);
            tab[2] = new PointF(200, 150);
            tab[3] = new PointF(250, 300);
            tab[4] = new PointF(180, 400);
            tab[5] = new PointF(120, 300);
            tab[6] = new PointF(30, 220);
            tab[7] = new PointF(50, 200);
            drawArea.DrawPolygon(new Pen(Color.Yellow), tab);
            int ilosc_przeciec = 0;
            int tilosc_przeciec = 0;
            int tmp = 0;

            for (int j = 0; j < 7; j++)
            {
                if ((Det2(x1, y1, tab[j].X, tab[j].Y, tab[j + 1].X, tab[j + 1].Y)) == 0)
                {
                    ilosc_przeciec = 1;
                    tmp = 8;
                    j = 8;
                }
            }

            for(int i = tmp; i < 7; i++)
            {
                tilosc_przeciec = 0;

                if ( Sign(Det2(x1, y1, x2, y2, tab[i].X, tab[i].Y)) != Sign(Det2(x1, y1, x2, y2, tab[i + 1].X, tab[i + 1].Y)) && Sign(Det2(tab[i].X, tab[i].Y, tab[i + 1].X, tab[i + 1].Y, x1, y1)) != Sign(Det2(tab[i].X, tab[i].Y, tab[i + 1].X, tab[i + 1].Y, x2, y2)))
                {
                    tilosc_przeciec++;
                }
                else if (Sign(Det2(x1, y1, x2, y2, tab[i].X, tab[i].Y)) == 0 && ((x1 < tab[i].X && tab[i].X < x2) && (y1 < tab[i].Y && tab[i].Y < y2)))
                {
                    tilosc_przeciec++;
                }
                else if (Sign(Det2(x1, y1, x2, y2, tab[i + 1].X, tab[i + 1].Y)) == 0 && ((x1 < tab[i + 1].X && tab[i + 1].X < x2) && (y1 < tab[i + 1].Y && tab[i + 1].Y < y2)))
                {
                    tilosc_przeciec++;
                }
                else if (Sign(Det2(tab[i].X, tab[i].Y, tab[i + 1].X, tab[i + 1].Y, x1, y1)) == 0 && ((tab[i].X < x1 && x1 < tab[i + 1].X) && (tab[i].Y < y1 && y1 < tab[i + 1].Y)))
                {
                    tilosc_przeciec++;
                }
                else if (Sign(Det2(tab[i].X, tab[i].Y, tab[i + 1].X, tab[i + 1].Y, x2, y2)) == 0 && ((tab[i].X < x2 && x2 < tab[i + 1].X) && (tab[i].Y < y2 && y2 < tab[i + 1].Y)))
                {
                    tilosc_przeciec++;
                }

                if (tilosc_przeciec > 0)
                {
                    ilosc_przeciec++;
                }
            }

            if(ilosc_przeciec%2 != 0)
            {
                label19.Text = "Punkt lezy wewnatrz wielokata!";
            }
            else
            {
                label19.Text = "Punkt lezy na zewnatrz wielokata!";
            }
        }
    }
}
