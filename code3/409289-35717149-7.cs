    public MainWindow()
    {
        InitializeComponent();
        this.MinWidth = 550; //this should be sum of actual width of visible tabs
        this.SizeChanged += window_SizeChanged;
    }
    private void window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        invisibletab.Width = this.ActualWidth - this.MinWidth; // where the MinWidth of the window should be the sum of the actual width of visible tabs
    }
