    public partial class MainWindow : Window
    {
        public class FileInfo
        {
            public string Name { get; set; }
            public DateTime LastModified { get; set; }
            public FileInfo(string name)
            {
                Name = name;
                LastModified = DateTime.Now;
            }
        }
        ObservableCollection<FileInfo> mFileNames = new ObservableCollection<FileInfo>();
        public ObservableCollection<FileInfo> FileNames
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
                            mFileNames.Add(new FileInfo("X"));
                        }));
                        Thread.Sleep(500);
                    }
                });
        }
    }
