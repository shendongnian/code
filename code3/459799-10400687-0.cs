    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public partial class MainForm : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Color[] colors = new Color[11];
    
            colors[0] = Color.Green;
            colors[1] = Interpolate(Color.Green, Color.Orange, 0.2);
            colors[2] = Interpolate(Color.Green, Color.Orange, 0.4);
            colors[3] = Interpolate(Color.Green, Color.Orange, 0.6);
            colors[4] = Interpolate(Color.Green, Color.Orange, 0.8);
            colors[5] = Color.Orange;
            colors[6] = Interpolate(Color.Orange, Color.Red, 0.2);
            colors[7] = Interpolate(Color.Orange, Color.Red, 0.4);
            colors[8] = Interpolate(Color.Orange, Color.Red, 0.6);
            colors[9] = Interpolate(Color.Orange, Color.Red, 0.8);
            colors[10] = Color.Red;
    
            Rectangle rect = new Rectangle(10, 10, 20, 90);
            for (int i = 0; i < colors.Length; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(colors[i]), rect);
                rect.Offset(20, 0);
            }
    
            base.OnPaint(e);
        }
    
        private static Color Interpolate(Color a, Color b, double t)
        {
            int R = (int)(a.R + (b.R - a.R) * t);
            int G = (int)(a.G + (b.G - a.G) * t);
            int B = (int)(a.B + (b.B - a.B) * t);
            return Color.FromArgb(R, G, B);
        }
    
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
