    public WebForm()
    {
        if ( !WebCore.IsRunning )
            WebCore.Initialize( new WebConfig() { UserAgent = "YourUserAgent" } );
     
        InitializeComponent();
    }
