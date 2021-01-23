    private void SendToFacebook(string facebookUserScreenName, string fbAppToken, string link, string linkName, string message, string caption, string imageUrl)
    {
       var client = new FacebookClient(fbAppToken);
       dynamic feedRez = client.Get(facebookUserScreenName);
       var userId = feedRez.id;
       var url = String.Format("https://graph.facebook.com/{0}/feed?access_token={1}", userId, fbAppToken);
       var req = WebRequest.Create(url);
       req.Method = "POST";
       req.ContentType = "application/x-www-form-urlencoded";
       var post = String.Format("{0}&message={1}&link={2}&name={3}&caption={4}&picture={4}",
                                     HttpUtility.UrlEncode(fbAppToken),
                                     HttpUtility.UrlEncode(message),
                                     HttpUtility.UrlEncode(link),
                                     HttpUtility.UrlEncode(linkName),
                                     HttpUtility.UrlEncode(caption),
                                     HttpUtility.UrlEncode(imageUrl));
       var byteArray = Encoding.UTF8.GetBytes(post);
       var stream = req.GetRequestStream();
       
       stream.Write(byteArray, 0, byteArray.Length);
       stream.Close();
       try
       {
          WebResponse response = req.GetResponse();
       }
       catch (Exception ex)
       {
          //log exception
       }
    }
