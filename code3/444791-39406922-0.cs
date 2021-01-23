     class Posts
    {
        public string PostId { get; set; }
        public string PostStory { get; set; }
        public string PostMessage { get; set; }
        public string PostPictureUri { get; set; }
        public Image PostImage { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
        private List<Posts> getFBPosts()
    {
         //Facebook.FacebookClient myfacebook = new Facebook.FacebookClient();
         string AppId = "--------";
         string AppSecret = "----------";
        var client = new WebClient();
        string oauthUrl = string.Format("https://graph.facebook.com/oauth/access_token?type=client_cred&client_id={0}&client_secret={1}", AppId, AppSecret);
        string accessToken = client.DownloadString(oauthUrl).Split('=')[1];
         FacebookClient myfbclient = new FacebookClient(accessToken);
       string versio= myfbclient.Version;
       var parameters = new Dictionary<string, object>();
       parameters["fields"] = "id,message,picture";
       string myPage="fanPage"; // put your page name
        dynamic result = myfbclient.Get(myPage +"/posts", parameters);
            
        List<Posts> postsList = new List<Posts>();
        int mycount=result.data.Count;
               
        for (int i = 0; i < result.data.Count; i++)
        {
            Posts posts = new Posts();
            posts.PostId = result.data[i].id;
            posts.PostPictureUri = result.data[i].picture;
            posts.PostMessage= result.data[i].message;
            
             var request = WebRequest.Create(posts.PostPictureUri);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                             posts.PostImage  = Bitmap.FromStream(stream);
            }
              postsList.Add(posts);
        }
        return postsList;
       
    }
