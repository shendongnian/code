        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
            Closing += new CancelEventHandler(MainWindow_Closing);
        }
              
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           LoadExternalXaml();
        }
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            SaveExternalXaml();
        }
        public void LoadExternalXaml()
        {
            if (File.Exists(@"C:\Test.xaml"))
            {
                using (FileStream stream = new FileStream(@"C:\Test.xaml", FileMode.Open))
                {
                    this.Content = XamlReader.Load(stream);
                }
            }
        }
        public void SaveExternalXaml()
        {
            using (FileStream stream = new FileStream(@"C:\Test.xaml", FileMode.Create))
            {
                XamlWriter.Save(this.Content, stream);
            }
        }
