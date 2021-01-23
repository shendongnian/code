    using AForge.Video;
    using AForge.Video.DirectShow;
    
    public partial class Form1 : Form
    {
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice CustomerWebcam;
        private int CustomerWebcam_CapabilitiesIndexMin;
        private int CustomerWebcam_CapabilitiesIndexMax;
        private bool bCustomerWebcam_capture;
        public Form1()
        {
            InitializeComponent();
        }
        // Some good info to make this more robust
        // http://haryoktav.wordpress.com/2009/03/21/webcam-in-c-aforgenet/
        //
        private void button1_Click(object sender, EventArgs e)
        {            
            CustomerWebcam = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
            CustomerWebcam.NewFrame += new NewFrameEventHandler(CustomerWebcam_NewFrame);
            int indexMin = -1;
            int MinPixels = 0;
            int indexMax = -1;
            int MaxPixels = 0;
            for (int i = 0; i < CustomerWebcam.VideoCapabilities.Length; i++)
            {
                int pixels = CustomerWebcam.VideoCapabilities[i].FrameSize.Height * CustomerWebcam.VideoCapabilities[i].FrameSize.Width; 
                if (indexMin == -1) { indexMin = i; MinPixels = pixels; }
                if (indexMax == -1) { indexMax = i; MaxPixels = pixels; }
                if (pixels < MinPixels) { indexMin = i; MinPixels = pixels; }
                if (pixels > MaxPixels) { indexMax = i; MaxPixels = pixels; }
            }
            CustomerWebcam_CapabilitiesIndexMin = indexMin;
            CustomerWebcam_CapabilitiesIndexMax = indexMax;
            CustomerWebcam.VideoResolution = CustomerWebcam.VideoCapabilities[indexMin];
            CustomerWebcam.DisplayPropertyPage(IntPtr.Zero);
            CustomerWebcam.Start();
        }
        void CustomerWebcam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (bCustomerWebcam_capture && 
                CustomerWebcam.VideoResolution == CustomerWebcam.VideoCapabilities[CustomerWebcam_CapabilitiesIndexMin])
            {
                string cam = CustomerWebcam.Source;
                CustomerWebcam.SignalToStop();
                CustomerWebcam.NewFrame -= new NewFrameEventHandler(CustomerWebcam_NewFrame);
                CustomerWebcam = null;
                CustomerWebcam = new VideoCaptureDevice(cam);
                CustomerWebcam.VideoResolution = CustomerWebcam.VideoCapabilities[CustomerWebcam_CapabilitiesIndexMax];
                CustomerWebcam.NewFrame += new NewFrameEventHandler(CustomerWebcam_NewFrame);
                CustomerWebcam.Start();
            }
            else
            if (bCustomerWebcam_capture && 
                CustomerWebcam.VideoResolution == CustomerWebcam.VideoCapabilities[CustomerWebcam_CapabilitiesIndexMax])
            {
                Bitmap video = (Bitmap)eventArgs.Frame.Clone();
                string cam = CustomerWebcam.Source;
                CustomerWebcam.SignalToStop();
                CustomerWebcam.NewFrame -= new NewFrameEventHandler(CustomerWebcam_NewFrame);
                CustomerWebcam = null;
                System.Random rnd = new Random();
                // Save as a random filename...
                video.Save("img" + Convert.ToString((int)(rnd.NextDouble() * 10000000)) + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                bCustomerWebcam_capture = false;
                CustomerWebcam = new VideoCaptureDevice(cam);
                CustomerWebcam.VideoResolution = CustomerWebcam.VideoCapabilities[CustomerWebcam_CapabilitiesIndexMin];
                CustomerWebcam.NewFrame += new NewFrameEventHandler(CustomerWebcam_NewFrame);
                CustomerWebcam.Start();
            }
            else
            {
                Bitmap video = (Bitmap)eventArgs.Frame.Clone();
                pictureBox1.Image = video;
            }
          
        }                   
      
        private void Form1_Load(object sender, EventArgs e)
        {
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CustomerWebcam.SignalToStop();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(CustomerWebcam == null))
                if (CustomerWebcam.IsRunning)
                {
                    CustomerWebcam.SignalToStop();
                    CustomerWebcam = null;
                }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bCustomerWebcam_capture = true;
        }
   
    }
