    public MainWindow()
    {
        td = new TestDependency();
        td.TestDateTime = DateTime.Now;
        this.DataContext = this;
        InitializeComponent();
    }
