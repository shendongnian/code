    namespace testimg
    {
        public partial class Form1 : Form
        {
            Bitmap myImage;
            public Form1()
            {
                InitializeComponent();
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                doimg pic = new doimg();
                myImage = pic.picture();
                Invalidate();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Enabled = true;
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                if (myImage != null)
                    e.Graphics.DrawImage(myImage,0,0);
            }
        }
    }
