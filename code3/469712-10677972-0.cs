    public partial class Form1 : Form
    {
        PointF picLander = new PointF(0.5f, 0.5f);
        static int th = 16;
 
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
         protected override  void OnPaint( PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Inch;
            Pen MyPen = new Pen(Color.Black, th / g.DpiX);
            g.DrawLine(MyPen, Convert.ToInt32(picLander.X), Convert.ToInt32(picLander.Y), 1, 1);
            g.DrawEllipse(MyPen, Convert.ToInt32(picLander.X), Convert.ToInt32(picLander.Y), 3, 5);
            this.Text = picLander.X.ToString() + "----" + picLander.Y.ToString();
        } 
         private void timer1_Tick(object sender, EventArgs e)
         {
             picLander.X = picLander.X +1;
             picLander.Y = picLander.Y +1;
             Invalidate();
         }
    }
