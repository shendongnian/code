    public partial class Form1 : Form
    {
        private int PEN_WIDTH = 5;
        private Point lastPoint = new Point(-1, -1);
        private System.Drawing.Drawing2D.GraphicsPath GP = new System.Drawing.Drawing2D.GraphicsPath();
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
        }
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            if (lastPoint.X == -1 && lastPoint.Y == -1)
            {
                lastPoint = pt;
            }
            else
            {
                GP.AddLine(lastPoint, pt);
                this.Refresh();
            }
            lastPoint = pt;
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen draw_pen = new Pen(Color.Blue, PEN_WIDTH)) 
            {
                Graphics g = e.Graphics;
                g.DrawPath(draw_pen, GP);
            }
        }
    }
