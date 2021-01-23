    public MainWindow()
    {
        InitializeComponent();       
        this.SizeChanged += window_SizeChanged;
    }
    private void window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        invisibletab.Width = this.ActualWidth - 550; // where the 550 is the sum of the actual width of visible tabs
    }
