        private DirectorySearchModel model = new DirectorySearchModel();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = model; //The model is already available as private member
        }
        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            dlg.SelectedPath = path;
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                path = dlg.SelectedPath;
                string pattern = "*.*";
                Action<string, string> proc = model.Search; // use existing model (the private member).
                cbResult = proc.BeginInvoke(path, pattern, null, null);
            }
        }
