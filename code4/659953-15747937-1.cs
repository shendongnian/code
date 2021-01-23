    public partial class MainWindow : Window
    {
        ObservableCollection<string> mFileNames = new ObservableCollection<string>();
        public ObservableCollection<string> FileNames
        {
            get
            {
                return mFileNames;
            }
        }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem((x) =>
                {
                    while (true)
                    {
                        Dispatcher.BeginInvoke((Action)(() =>
                        {
                            mFileNames.Add("X");
                        }));
                        Thread.Sleep(500);
                    }
                });
        }
    }
