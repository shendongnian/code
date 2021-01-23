    public MainWindow()
    {
        InitializeComponent();
        td = new TestDependency();
        td.TestDateTime = DateTime.Now;
        DataContext = this;
    }
