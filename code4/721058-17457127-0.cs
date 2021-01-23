    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Cursor = Cursors.Cross;
        }
        private Bitmap bmp = null;
        private Graphics G = null;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (bmp == null)
                {
                    bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    G = Graphics.FromImage(bmp);
                }
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (bmp != null && G != null)
                {
                    Rectangle rc = new Rectangle(Cursor.Position, new Size(1, 1));
                    rc.Inflate(pictureBox1.Width / 2, pictureBox1.Height / 2);
                    G.CopyFromScreen(rc.Location, new Point(0, 0), rc.Size);
                    pictureBox1.Image = bmp;
                }    
            }
        }
    }
