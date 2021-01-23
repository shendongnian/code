    public partial class Form1 : Form
    {
		Rectangle r = Rectangle.Empty;
		Pen redPen = new Pen(Color.Red);
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
			r = new Rectangle(50, 50, 100, 100);
			Refresh();
        }
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (r != Rectangle.Empty)
			{
				e.Graphics.DrawRectangle(redPen, r);
			}
		}
    }
