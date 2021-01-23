    public frmMain()
    {
        this.InitializeComponent();
        btnKeboardCollector.Loaded += MyBoard_Loaded;
        btnKeboardCollector.LostFocus += btnKeboardCollector_LostFocus;
        btnKeboardCollector.KeyUp += KeyUpHandler;
    }
    void MyBoard_Loaded(object sender, RoutedEventArgs e)
    {
        // I do other initialization here
        btnKeboardCollector.Focus(Windows.UI.Xaml.FocusState.Programmatic);
    }
    void btnKeboardCollector_LostFocus(object sender, RoutedEventArgs e)
    {
        btnKeboardCollector.Focus(Windows.UI.Xaml.FocusState.Programmatic);
    }
    
    private void KeyUpHandler(object sender, KeyRoutedEventArgs e)
    {
    }
