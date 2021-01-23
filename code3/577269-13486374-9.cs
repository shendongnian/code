    public partial class Form1 : Form
    {
        private GifImage gifImage = null;
        private string filePath = @"C:\Users\Jeremy\Desktop\ExampleAnimation.gif";
         
        public Form1()
        {
            InitializeComponent();
            //a) Normal way
            //pictureBox1.Image = Image.FromFile(filePath);
            //b) We control the animation
            gifImage = new GifImage(filePath);
            gifImage.ReverseAtEnd = false; //dont reverse at end
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Start the time/animation
            timer1.Enabled = true;
        }
        //The event that is animating the Frames
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = gifImage.GetNextFrame();
        }
    }
