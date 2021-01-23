    public partial class MainWindow : Window
    {
        private BackgroundWorker worker;
    
        public MainWindow()
        {
            InitializeComponent();
    
            Loaded += MainWindow_Loaded;
        }
    
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
            consolemessage("STARTUP", "Verifying existence of essential files...");
        }
    
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!File.Exists("Interop.NATUPNPLib.dll"))
                Download("link here", "Interop.NATUPNPLib.dll");
    
            if (!File.Exists("LICENSE.txt"))
                Download("link here", "LICENSE.txt");
        }
    
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Signal your UI that the files are now available here if needed.
            consolemessage("STARTUP", "Essential file validation completed!");
        }
    }
