    private ICollectionView defaultView;
    public MainWindow()
    {
        InitializeComponent();
        string[] items = new string[]
        {
            "Asdf",
            "qwer",
            "sdfg",
            "wert",
        };
        this.defaultView = CollectionViewSource.GetDefaultView(items);
        this.defaultView.Filter =
            w => ((string)w).Contains(SearchTextBox.Text);
        MyDataGrid.ItemsSource = this.defaultView;
    }
    private void SearchButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.defaultView.Refresh();
    }
