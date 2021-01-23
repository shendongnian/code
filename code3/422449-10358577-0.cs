    public MainPage()
    {
        InitializeComponent();
    
        this.OrientationChanged += OnOrientationChanged;
    }
    
    private void OnOrientationChanged( object sender, OrientationChangedEventArgs e )
    {
        double val = MySlider.Value;
        MySlider.Value = 0;
    
        var bw = new BackgroundWorker();
        bw.DoWork += ( _, __ ) => Thread.Sleep( 100 );
        bw.RunWorkerCompleted += ( _, __ ) => Dispatcher.BeginInvoke( () => MySlider.Value = val );
        bw.RunWorkerAsync();
    }
