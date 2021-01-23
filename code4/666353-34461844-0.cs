    public partial class SampleOfQueue : Form
    {
        public SampleOfQueue() { InitializeComponent(); }
        DBContext db = new DBContext();
        int Queue;
        private void btnStartApp_Click(object sender, EventArgs e)
        {
            Queue = 0;
            DownloadQueue();
        }
        private void DownloadQueue()
        {
            switch (Queue)
            {
                case 0:
                    {
                        DownloadFile("http://images.forbes.com/media/lists/53/2009/tom-cruise.jpg", "Tom Cruise 1", "");
                        Queue += 1; break;
                    }
                case 1:
                    {
                        DownloadFile("https://upload.wikimedia.org/wikipedia/commons/6/69/Tom_Cruise_Collateral.jpg", "Tom Cruise 2", "");
                        Queue += 1; break;
                    }
                case 2:
                    {
                        // Other....
                        Queue += 1; break;
                    }
                default: break;
            }
        }
        public void DownloadFile(string urlAddress, string ImageName, string ImageFarsiName)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri(urlAddress);
            webClient.DownloadFileAsync(URL, "d:\\x.jpg");
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            DownloadQueue();
            if (Queue == 3) { MessageBox.Show("finish"); }
        }
    }
