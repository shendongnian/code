    public partial class Form1 : Form
    {
        Bitmap myImage;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            myImage = new Bitmap("Your Image Name Here");
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
            if (myImage != null)
                e.Graphics.DrawImage(myImage,0,0);
        }
        
    }
