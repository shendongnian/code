    public partial class Form1 : Form
    {
        bool mDown;
        SolidBrush sbGray = new SolidBrush(Color.Gray);
        SolidBrush sbGreen = new SolidBrush(Color.LimeGreen);
        SolidBrush sbTemp;
        Point mPosition = new Point();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Temp\Test.jpg");
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mDown = true;
            mPosition = new Point(e.X, e.Y);
            sbTemp = sbGray;
            pictureBox1.Invalidate();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mDown)
            {
                mPosition = new Point(e.X, e.Y);
                sbTemp = sbGray;
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mPosition = new Point(e.X, e.Y);
            sbTemp = sbGreen;
            pictureBox1.Invalidate();
            mDown = false;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (sbTemp != null)
            {
                e.Graphics.FillEllipse(sbTemp, mPosition.X -5, mPosition.Y -5, 10, 10);
            }
        }
    }
