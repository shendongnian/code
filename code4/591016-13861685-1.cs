     public partial class Form1 : Form
        {
            private Graphics g = null;
    
            private Pen z = new Pen(new SolidBrush(Color.Blue));
    
            public Form1()
            {
                InitializeComponent();
    
                g = CreateGraphics();
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawLine(z, p, p2);
            }
    
            private Point p = new Point();
            private Point p2 = new Point();
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    p = e.Location;
    
                p2 = e.Location;
    
                Invalidate();
            }
        }
