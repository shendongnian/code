    private Timer playingTimer = new Timer();
    public Main()
    {
        InitializeComponent();
        
        playingTimer.Enabled = false;
        playingTimer.Tick += renderSubtitles;
    }
