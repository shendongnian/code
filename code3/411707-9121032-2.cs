    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
    }
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        this.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Right - this.Width;
        this.Top = 0;
        this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
    }
