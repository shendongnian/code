    public HomePage()
    {
        InitializeComponent();
        _caseBrowser = new StandardCaseBrowserControl { IsEnabled = true };
        _caseBrowser.DataContextChanged += _OnCaseBrowsesrDataContextChanged;
    }
    private void OnCaseBrowserDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (_caseBrowser.DataContext != null)
            DataContext = _caseBrowser.DataContext;
    }
