    using Emgu.CV;
    using Emgu.CV.Structure;
    ...
    public partial class Form1 : Form
    {
        public Capture cvWebCam;
        public Form1()
        {
            InitializeComponent();
            try
            {
                cvWebCam = new Capture();
                timer1.Start();
            }
            catch
            {
                Console.WriteLine("Default camera not found or could not start");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cvWebCam != null)
            using (Emgu.CV.Image<Bgr, byte> frame = cvWebCam.QueryFrame())
            {
                pictureBox1.BackgroundImage = frame.ToBitmap();
            }
        }
    }
