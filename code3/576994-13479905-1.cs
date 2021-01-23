    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // 100x80 image
            Image asdf = Image.FromFile("asdf.bmp", true);
            // twice the size, 200x160
            Image asdf2 = Image.FromFile("asdf2.bmp", true);
            // same image, different aspect ratio: 200x80
            Image asdf3 = Image.FromFile("asdf3.bmp", true);
            Bitmap asdfBmp = new Bitmap(asdf);
            Bitmap asdf2Bmp = new Bitmap(asdf2);
            Bitmap asdf3Bmp = new Bitmap(asdf3);
            pictureBox1.Image = cropImage(asdfBmp);
            pictureBox2.Image = cropImage(asdf2Bmp);
            pictureBox3.Image = cropImage(asdf3Bmp);
        }
        private Bitmap cropImage(Bitmap sourceBitmap)
        {
            double x = 0;
            double y = 0;
            double w = 0;
            double h = 0;
            double inputX = 10;
            double inputY = 10;
            double inputW = 50;
            double inputH = 50;
            // integer division " 10 / 100 " will return 0, use doubles or floats.
            // furthermore you don't have to convert anything to a string or back here.
            x = sourceBitmap.Width * inputX / 100.0;
            y = sourceBitmap.Height * inputY / 100.0;
            w = sourceBitmap.Width * inputW / 100.0;
            h = sourceBitmap.Height * inputH / 100.0;
            // casting to int will just cut off all decimal places. you could also round.
            Rectangle cropArea = new Rectangle((int)x, (int)y, (int)w, (int)h);
            return sourceBitmap.Clone(cropArea, sourceBitmap.PixelFormat);
        }
    }
