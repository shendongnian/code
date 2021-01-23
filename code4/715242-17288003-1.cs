    public partial class Form1 : Form
    {
        bool mDown;
        SolidBrush sbGray = new SolidBrush(Color.Gray);
        SolidBrush sbGreen = new SolidBrush(Color.LimeGreen);
        SolidBrush sbTemp;
        Point mPosition = new Point();
        public List<Point> points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Temp\Test.jpg");
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mDown = true;
                mPosition = new Point(e.X, e.Y);
                sbTemp = sbGray;
                pictureBox1.Invalidate();
            }
            else
            {
                points.Clear();
                sbTemp = null;
                pictureBox1.Invalidate();
            }
            
            
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
            if (e.Button == MouseButtons.Left)
            {
                mPosition = new Point(e.X, e.Y);
                points.Add(mPosition);
                sbTemp = sbGreen;
                pictureBox1.Invalidate();
                mDown = false;
            }
            
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (sbTemp != null)
            {
                e.Graphics.FillEllipse(sbTemp, mPosition.X -5, mPosition.Y -5, 10, 10);
            }
            if (points != null)
            {
                foreach (var loc in points)
                {
                    e.Graphics.FillEllipse(sbGreen, loc.X - 5, loc.Y - 5, 10, 10);
                }
            }
        }
    }
