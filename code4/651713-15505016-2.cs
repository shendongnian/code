    public MainWindow()
    {
        InitializeComponent();
    
        PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
    }
    
    void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Space)
        {
            Log("Intercepted space in preview");
            e.Handled = true;
        }
    }
