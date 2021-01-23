    public MainWindow()
    {
        this.Closing += new CancelEventHandler(MainWindow_Closing);
        InitializeComponent();
    }
    
    void MainWindow_Closing(object sender, CancelEventArgs e)
    {
       // Closing logic here.
    }
