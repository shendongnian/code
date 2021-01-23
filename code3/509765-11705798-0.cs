    public partial class Form1 : Form
    {
        Bitmap nullBitmap = new Bitmap(1, 1); // create a 1 pixel bitmap
        Bitmap myImage = new Bitmap("Load your Image Here"); // Load your image
        bool showImage;  // boolean variable so we know what image is assigned
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = myImage;
            showImage = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (showImage)
            {
                pictureBox1.Image = nullBitmap;
                showImage = false; 
            }
            else
            {
                pictureBox1.Image = myImage;
                showImage = true;
            }
        }
    }
