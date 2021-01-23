    // store when we last clicked the toggle B user control visibility
    private Stopwatch _sinceLastMouseClick;
    
    public Form1()
    {
        InitializeComponent();
        // instantiate the stopwatch and start it ticking
        _sinceLastMouseClick = new Stopwatch();
        _sinceLastMouseClick.Start();
    }
