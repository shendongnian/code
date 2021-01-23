    using System.ComponentModel;
    public partial class MainWindow : Window
    {
        BackgroundWorker bgw;
        public MainWindow()
        {
            InitializeComponent();
            bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
        }
        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            updateButton.IsEnabled = true;
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(10000); //Simulating your work
        }
        
        private void startWorkThread()
        {
            bgw.RunWorkerAsync();
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (bgw.IsBusy != true)
            {
                updateButton.IsEnabled = false;
                startWorkThread();
            }
        }
    }
