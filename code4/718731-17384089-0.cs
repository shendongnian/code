    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }
        private Random R = new Random();
        private List<System.Drawing.Drawing2D.GraphicsPath> Paths = new List<System.Drawing.Drawing2D.GraphicsPath>();
        private void button1_Click(object sender, EventArgs e)
        {
            Point pt1 = new Point(R.Next(this.Width), R.Next(this.Height));
            Point pt2 = new Point(R.Next(this.Width), R.Next(this.Height));
            System.Drawing.Drawing2D.GraphicsPath shape = new System.Drawing.Drawing2D.GraphicsPath();
            shape.AddRectangle(new Rectangle(new Point(Math.Min(pt1.X,pt2.X), Math.Min(pt1.Y, pt2.Y)), new Size(Math.Abs(pt2.X - pt1.X), Math.Abs(pt2.Y - pt1.Y))));
            Paths.Add(shape);
            this.Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            foreach (System.Drawing.Drawing2D.GraphicsPath Path in Paths)
            {
                G.DrawPath(Pens.Black, Path);
            }
        }
    }
