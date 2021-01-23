    public partial class Form1 : Form
    {
        Point cursor;
        Point lastPoint;
        System.Drawing.Drawing2D.GraphicsPath curPath = null;
        private List<System.Drawing.Drawing2D.GraphicsPath> paths = new List<System.Drawing.Drawing2D.GraphicsPath>();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
        }
        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (System.Drawing.Drawing2D.GraphicsPath gp in paths)
            {
                e.Graphics.DrawPath(Pens.Red, gp);
            }
            e.Graphics.DrawLine(Pens.Black, new Point(cursor.X, 0), new Point(cursor.X, pictureBox1.Height));
            e.Graphics.DrawLine(Pens.Black, new Point(0, cursor.Y), new Point(pictureBox1.Width, cursor.Y));
        }
        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                lastPoint = new Point(e.X, e.Y);
                curPath = new System.Drawing.Drawing2D.GraphicsPath();
                paths.Add(curPath);
            }
        }
        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = new Point(e.X, e.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point newPoint = new Point(e.X, e.Y);
                curPath.AddLine(lastPoint, newPoint);
                lastPoint = newPoint;
                pictureBox1.Refresh();
            }
            pictureBox1.Refresh();
        }
    }
