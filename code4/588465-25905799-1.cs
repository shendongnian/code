    using AForge.Video;
    using AForge.Video.DirectShow;
    
    public partial class Form1 : Form
    {
        private int PreviewRefreshDelayMS = 40;
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice CustomerWebcam;
        private int CustomerWebcam_CapabilitiesIndexMin;
        private int CustomerWebcam_CapabilitiesIndexMax;
        private bool bCustomerWebcam_capture;
        private Bitmap CustomerWebcam_bitmap;
        private System.DateTime CustomerWebcam_nextframetime = DateTime.Now;
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
            if (CustomerWebcam_bitmap != null)
            { 
                CustomerWebcam_bitmap.Dispose();
                CustomerWebcam_bitmap = null;
            }
            
            if (bCustomerWebcam_capture)
            {
                CustomerWebcam_bitmap = (Bitmap)eventArgs.Frame.Clone(); 
                System.Random rnd = new Random();
                CustomerWebcam_bitmap.Save("img" + Convert.ToString((int)(rnd.NextDouble() * 10000000)) + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                bCustomerWebcam_capture = false;
                ((Bitmap)eventArgs.Frame).Dispose();
            }
            else
                if (DateTime.Now > CustomerWebcam_nextframetime)
            {
                CustomerWebcam_bitmap = (Bitmap)eventArgs.Frame.Clone();
                pictureBox1.Image = CustomerWebcam_bitmap;
                CustomerWebcam_nextframetime = DateTime.Now.AddMilliseconds(PreviewRefreshDelayMS);
                ((Bitmap)eventArgs.Frame).Dispose();
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
            CustomerWebcam = null;
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
