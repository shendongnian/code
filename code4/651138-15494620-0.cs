      private void Do()
            {
                string app_id = "157873644371675";
                string app_secret = "c27a10c347af4280720fa3d76c9ae08c";
                string scope = "publish_stream,manage_pages";
    
                if (Request["code"] == null)
                {
                    Response.Redirect(string.Format(
                        "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                        app_id, Request.Url.AbsoluteUri, scope));
                }
                else
                {
                    Dictionary<string, string> tokens = new Dictionary<string, string>();
    
                    string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                        app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);
    
                    HttpWebRequest request = System.Net.WebRequest.Create(url) as HttpWebRequest;
    
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
    
                        string vals = reader.ReadToEnd();
    
                        foreach (string token in vals.Split('&'))
                        {
                            //meh.aspx?token1=steve&token2=jake&...
                            tokens.Add(token.Substring(0, token.IndexOf("=")),
                                token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                        }
                    }
    
                    string access_token = tokens["access_token"];
    
                    var client = new FacebookClient(access_token);
                   
                    dynamic parameters = new ExpandoObject();
                    parameters.message = "Check out this funny article";
                    parameters.link = "http://www.natiska.com/article.html";
                    parameters.picture = "http://www.natiska.com/dav.png";
                    parameters.name = "Article Title";
                    parameters.caption = "Caption for the link";
    
                    //446533181408238 is my fan page
                    client.Post("/446533181408238/feed", parameters);
                
                }
                  }
