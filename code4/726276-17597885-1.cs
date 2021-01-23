    public MainWindow()
    {
        OCContext = new ObservableCollection<string>();
        MyList = new ObservableCollection<string>();
        MyList.Add("Item 1");
        MyList.Add("Item 2");
        InitializeComponent();
        
    }
    public ObservableCollection<string> MyList { get; set; }
    public ObservableCollection<string> OCContext { get; set; }
    public string MySelectedItem { get; set; }
    
    private void ContextMenu_Opened(object sender, EventArgs e)
    {
        ContextMenu.Items.Clear();
        foreach (var str in OCContext)
        {
            var item = new MenuItem();
            item.Header = str;
            item.Click += Content_MouseLeftButtonUp;
            ContextMenu.Items.Add(item);
        }
    }
    
    private void Content_MouseLeftButtonUp(object sender, EventArgs e)
    {
        var s = sender as MenuItem;
        if (s == null) return;
        var ic = s.Header.ToString();
        
        MyList.Add(ic);
        OCContext.Remove(ic);
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (MySelectedItem != null)
        {
            OCContext.Add(MySelectedItem);
            MyList.Remove(MySelectedItem);
        }
    }
