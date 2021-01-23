    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        private BackgroundWorker bw = new BackgroundWorker();
        public MainPage()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            FireAlways();
        }
      public void FireAlways()
      {
        //some code
      }
     private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
     {
         if (bw.IsBusy != true)
         {
             bw.RunWorkerAsync();
         }
     }
      
    }
