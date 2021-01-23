    using AudioSwitcher.AudioApi.CoreAudio;
    public MainWindow()
    {
    
    InitializeComponent();
    
    CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
    
    double vol = defaultPlaybackDevice.Volume;
    
    defaultPlaybackDevice.Volume = defaultPlaybackDevice.Volume - 5.0;
    
    defaultPlaybackDevice.Volume = defaultPlaybackDevice.Volume + 5.0;
    
    }
