    public class FacebookPageInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class FacebookPost
    {
        public string Message { get; set; }
        // ReSharper disable once InconsistentNaming
        public string Created_Time { get; set; }
        public string Id { get; set; }
    }
    public class FacebookPagingInfo
    {
        public string Previous { get; set; }
        public string Next { get; set; }
    }
    public class FacebookPostData
    {
        public List<FacebookPost> Data { get; set; }
        public FacebookPagingInfo Paging { get; set; }
    }
    public class Friend
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    // get access token
    string oauthUrl = $"https://graph.facebook.com/oauth/access_token?type=client_cred&client_id={appId}&client_secret={appSecret}";
    string accessToken = client.DownloadString(oauthUrl).Split('=')[1];
    // get data and deserialize it
    var fbClient = new FacebookClient(accessToken);
    var fbData = fbClient.Get("/wikipedia/").ToString();
    var info = JsonConvert.DeserializeObject<FacebookPageInfo>(fbData);
    fbData = fbClient.Get("/wikipedia/posts").ToString();
    var posts = JsonConvert.DeserializeObject<FacebookPostData>(fbData);
