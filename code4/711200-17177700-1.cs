    // Constructor
    public MainPage()
    {
        InitializeComponent();
        this.Loaded += new RoutedEventHandler(MainPage_Loaded);
    }
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        var service = new TwitterService("yourconsumerKey", "yourconsumerSecret");
        service.AuthenticateWith("youraccessToken", "youraccessTokenSecret");
        service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions() { ScreenName = "SCREENNAME" }, (ts, rep) =>
            {
                if (rep.StatusCode == HttpStatusCode.OK)
                {
                    //bind
                    this.Dispatcher.BeginInvoke(() => { tweetList.ItemsSource = ts; });
                }
            });
    }
