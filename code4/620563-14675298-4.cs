    public MainWindow()
    {
        InitializeComponent();
        listBox1.ItemsSource = new List<ListItemViewModel>
        {
            new ListItemViewModel { Name = "Foo", Description = "Foo description" },
            new ListItemViewModel { Name = "Bar", Description = "Bar description" }
        };
    }
