    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    public partial class MainWindow : Window
    {
        private BackgroundWorker bw = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            // Set up background worker to allow progress reporting and cancellation
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            // This is your main work process that records progress
            bw.DoWork += new DoWorkEventHandler(SomeClass.DoWork);
            // This will update your page based on that progress
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            // This starts your background worker and "DoWork()"
            bw.RunWorkerAsync();
            // When this page closes, this will run and cancel your background worker
            this.Closing += new CancelEventHandler(Page_Unload);
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BitmapImage bImg = new BitmapImage();
            bool connected = false;
            string response = e.ProgressPercentage.ToString(); // will either be 1 or 0 for true/false -- this is the result recorded in DoWork()
            if (response == "1")
                connected = true;
            // Do something with the result we got
            if (!connected)
            {
                bImg.BeginInit();
                bImg.UriSource = new Uri("Images/network_off.jpg", UriKind.Relative);
                bImg.EndInit();
                imgNtwkInd.Source = bImg;
            }
            else
            {
                bImg.BeginInit();
                bImg.UriSource = new Uri("Images/network_on.jpg", UriKind.Relative);
                bImg.EndInit();
                imgNtwkInd.Source = bImg;
            }
        }
        private void Page_Unload(object sender, CancelEventArgs e)
        {
            bw.CancelAsync();  // stops the background worker when unloading the page
        }
    }
    public class SomeClass
    {
        public static bool connected = false;
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            int i = 0;
            do 
            {
                connected = CheckConn();  // do some task and get the result
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                    // Record your result here
                    if (connected)
                        bw.ReportProgress(1);
                    else
                        bw.ReportProgress(0);
                }
            }
            while (i == 0);
        }
        private static bool CheckConn()
        {
            bool conn = false;
            Ping png = new Ping();
            string host = "SomeComputerNameHere";
            try
            {
                PingReply pngReply = png.Send(host);
                if (pngReply.Status == IPStatus.Success)
                    conn = true;
            }
            catch (PingException ex)
            {
                // write exception to log
            }
            return conn;
        }
    }
