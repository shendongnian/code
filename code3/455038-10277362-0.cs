    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.Image = this.Draw(this.pictureBox1.Width, this.pictureBox1.Height);
        }
        public Bitmap Draw(int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(new SolidBrush(Color.Tomato), 10, 10, 100, 100);
            return bitmap;
        }
      }
    }
