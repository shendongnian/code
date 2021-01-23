    public partial class Form1 : Form
    {
        private readonly ServiceHost _serviceHost;
       
        public Form1()
        {
            // Construct the service host using a singleton instance of the
            // PictureService service, passing in a delegate that points to
            // the ShowPicture method defined below
            _serviceHost = new ServiceHost(new PictureService(ShowPicture));
            InitializeComponent();
        }
        // Display the given picture on the form
        internal void ShowPicture(Image picture)
        {
            Invoke(((ThreadStart) (() =>
                                       {
                                           // This code runs on the UI thread
                                           // by virtue of using Invoke
                                           pictureBox1.Image = picture;
                                       })));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Open the WCF service when the form loads
            _serviceHost.Open();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close the WCF service when the form closes
            _serviceHost.Close();
        }
    }
