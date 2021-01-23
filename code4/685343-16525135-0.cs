    protected void Page_Load(object sender, EventArgs e){
    _consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
    _consumerSecret = ConfigurationManager.AppSettings["ConsumerKey"];
    _accessToken = ConfigurationManager.AppSettings["accessToken"];
    _accessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"];
    TwitterClientInfo twitterClientInfo = new TwitterClientInfo();
    twitterClientInfo.ConsumerKey = _consumerKey;
    twitterClientInfo.ConsumerSecret = _consumerSecret;
    TwitterService service = new TwitterService(twitterClientInfo);
    service.AuthenticateWith(_accessToken, _accessTokenSecret);
    var tweets = service.Search(new SearchOptions { Q = "#MetGala", Count = 100 });
    if (tweets != null)
    {
        foreach (var tweet in tweets.Statuses)
        {
            System.Diagnostics.Debug.WriteLine("{0} says '{1}", tweet.User.ScreenName, tweet.Text);
        }
    }
    else
    {
        System.Diagnostics.Debug.WriteLine("FAIL");
    }
    FacebookFeed();
}
