The issue with this code is doSomeThing() method is running in UI Thread. So, the Button is not properly disabled. If we refactor the code so that doSomeThing() method runs in a different thread, it will just work fine. Here is a simple example using BackgroundWorker; however the idea is we should not run time consuming stuffs in UI thread. Here is the refactored code:
    public partial class ButtonEnableTest : Window
    {
        private BackgroundWorker worker = new BackgroundWorker();
        public ButtonEnableTest()
        {
            InitializeComponent();
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.btn.IsEnabled == false)
            {
                this.btn.IsEnabled = true;
            }
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            doSomeThing();
        }
        private void doSomeThing()
        {
            int i = 5;
            while ( i > 0)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(2000));
                System.Diagnostics.Debug.WriteLine("Woke up " + i);
                i--;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button) sender;
            System.Diagnostics.Debug.WriteLine("at ButtonClick");
            if (btn.IsEnabled)
            {
                btn.IsEnabled = false;
                this.worker.RunWorkerAsync();
            }
        }
    }
