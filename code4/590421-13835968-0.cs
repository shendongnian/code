    public partial class MainWindow : Window
    {
        Window1 splash;
        BackgroundWorker bg;
        public MainWindow()
        {
            
            InitializeComponent();
            bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            splash.Hide();
        }
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(10000);
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            splash = new Window1();
            splash.Show();
            bg.RunWorkerAsync();
        }
    }
