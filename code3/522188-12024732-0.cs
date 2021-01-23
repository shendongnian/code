    public partial class Form1 : Form
    {
        Image myImage;
        AnimatedGif myGif;
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
            myImage = Image.FromFile(@"D:\fananimation.gif");
            bitmap = new Bitmap(myImage);
            bitmap.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
            this.pictureBox1.Image = bitmap;
        }
    }
