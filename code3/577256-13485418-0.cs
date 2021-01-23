    public partial class Form1 : Form
    {
        Graphics g = null;
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromHwnd(Handle);
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Brush b = new SolidBrush(Color.Black);
            Pen pen = new Pen(b, 20.5f);
            Point p1 = new Point(0, 0);
            Point p2 = new Point(this.Width, this.Height);
            g.DrawLine(pen, p1, p2);
        }
    }
