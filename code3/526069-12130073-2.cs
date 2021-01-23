	public MainWindow()
    {
        InitializeComponent();
        var tab = new MyTabItem {MyContent = "Content", MyTitle = "Title"};
        MyTabControl.Items.Add(tab);
    }
