    public DatabaseTableWindow(string tableName, DataTable fields, string primaryKey)
    {
        InitializeComponent();
        this.tableName = tableName;
        this.fields = fields;
        this.primaryKey = primaryKey;
        lblTableName.Content = tableName;
        Loaded += new RoutedEventHandler(MainWindow_Loaded);        
    }
    
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        double x = this.ActualWidth;
    }
