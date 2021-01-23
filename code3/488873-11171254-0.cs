    public MainWindow()
    {
        InitializeComponent();
        this.MouseMove += new MouseEventHandler(MainWindow_MouseMove);
    }
    void MainWindow_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            //do something
        }
    }
