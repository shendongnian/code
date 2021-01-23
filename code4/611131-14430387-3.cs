    public MainWindow()
        {
        testClass testObject = new testClass();
        testObject.tabs = new List<TabItem>();
        testObject.tabs.Add(new TabItem());
        testObject.tabs.Add(new TabItem());
        testObject.tabs[0].Header = "NO WAY";
        testObject.tabs[1].Header = "ON WAY";
            
        testObject.tabs[0].Content = "WHAT";
        testObject.tabs[1].Content = "HELL";
        InitializeComponent();
            
        this.DataContext = testObject ;
    }
    class testClass
    {
        public List<TabItem> tabs { set; get; }
    }
