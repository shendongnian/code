    public partial class Form1 : Form
    {
        Bitmap chip = new Bitmap(40, 40, PixelFormat.Format32bppArgb);
        public Form1()
        {
            InitializeComponent();
            using (Graphics g = Graphics.FromImage(chip))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillEllipse(new SolidBrush(Color.FromArgb(128, 255, 80, 0)), 1, 1, 38, 38);
            }
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(pictureBox2.Image))
            {
                g.Clear(Color.Yellow);
            }
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Text = e.Location.ToString();
                using (Graphics g = Graphics.FromImage(pictureBox2.Image))
                {
                    g.DrawImage(chip, e.Location.X - 20, e.Location.Y - 20);
                }
                pictureBox2.Invalidate();
            }
        }
    }
