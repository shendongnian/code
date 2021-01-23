    public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            ResourceDictionary rd = new ResourceDictionary();
            rd.Add("one", "ONE");
            rd.Add("two", "TWO");
            rd.Add("three", "THREE");
            this.Resources.MergedDictionaries.Add(rd);
        }
