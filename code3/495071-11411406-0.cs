    public class Twitter
    {
        private TwitterService service;
        private OAuthRequestToken requestToken;
        public Twitter(String consumerKey, String consumerSecret)
        {
            service = new TwitterService(consumerKey, consumerSecret);
            requestToken = service.GetRequestToken();
        }
        public void Login(String username, String password)
        {
            Uri uri = service.GetAuthorizationUri(requestToken);
            CookieContainer cookieContainer = new CookieContainer();
            String response = HttpUtil.GetResponseString(uri, cookieContainer);
            int startIndex = response.IndexOf("authenticity_token\" type=\"hidden\" value=\"") + 41;
            int endIndex = response.IndexOf("\"", startIndex + 1);
            String authenticity_token = response.Substring(startIndex, endIndex - startIndex);
            startIndex = response.IndexOf("name=\"oauth_token\" type=\"hidden\" value=\"") + 40;
            endIndex = response.IndexOf("\"", startIndex + 1);
            String oauth_token = response.Substring(startIndex, endIndex - startIndex);
            String postData = "authenticity_token=" + authenticity_token +
                              "&oauth_token=" + oauth_token +
                              "&session%5Busername_or_email%5D=" + username +
                              "&session%5Bpassword%5D=" + password;
            response = HttpUtil.GetResponseString(new Uri("https://api.twitter.com/oauth/authorize"), postData, cookieContainer);
            if (response.Contains("Invalid user name or password"))
            {
                return;
            }
            startIndex = response.IndexOf("<code>") + 6;
            endIndex = response.IndexOf("</code>");
            String pin = response.Substring(startIndex, endIndex - startIndex);
            OAuthAccessToken access = service.GetAccessToken(requestToken, pin);
            service.AuthenticateWith(access.Token, access.TokenSecret);
            
        }
        public List<TwitterStatus> GetMentiones()
        {
            return service.ListTweetsMentioningMe().ToList<TwitterStatus>();
        }
    }
