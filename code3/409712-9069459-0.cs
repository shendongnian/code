    public static string Token = "XXX"
    public static string TokenSecret = "XXX"
    public static string ConsumerKey = "XXX"
    public static string ConsumerSecret = "XXX"
    public static string Callback = "XXX"
    private static TwitterClientInfo TwitterClientInfo = new TwitterClientInfo()
    {
        ConsumerKey = ConsumerKey,
        ConsumerSecret = ConsumerSecret,
    };
    private static TwitterService TwitterService = new TwitterService(TwitterClientInfo);
    public static bool SetUpTwitter()
    {
        var OAuthCredentials = new OAuthCredentials
        {
            Type = OAuthType.RequestToken,
            SignatureMethod = OAuthSignatureMethod.HmacSha1,
            ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
            ConsumerKey = ConsumerKey,
            ConsumerSecret = ConsumerSecret,
            CallbackUrl = "",
        };
        OAuthRequestToken requestToken = TwitterService.GetRequestToken(Callback);
        Uri authUrl = TwitterService.GetAuthorizationUri(requestToken, Callback);
        Process.Start(authUrl.AbsoluteUri);
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(30);
        while (currentTime < endTime)
        {
            currentTime = DateTime.Now;
        }
        OAuthAccessToken accessToken = TwitterService.GetAccessToken(requestToken);
        return SendMessage(accessToken.Token, accessToken.TokenSecret, "Send Sample Tweet");
    }
    public static bool SendMessage(string token, string tokenSecret, string message)
    {
        Token = token;
        TokenSecret = tokenSecret;
        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(tokenSecret))
            return SetUpTwitter();
        try
        {
            TwitterService.AuthenticateWith(token, tokenSecret);
            TwitterService.SendTweet(message);
            return true;
        }
        catch
        {
            return false;
        }
    }
