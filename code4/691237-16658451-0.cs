    ShortGuid sessionID = ShortGuid.NewGuid ();
    Session.Add (sessionID.ToString (), "asdasdasdasd");
    string encodedURL = Convert.ToBase64String (Encoding.Unicode.GetBytes (HttpContext.Current.Request.Url.PathAndQuery));	
    WebClient client = new WebClient ();
    NameValueCollection data = new NameValueCollection ();
    data.Add ("UserName", "asdasd");
    data.Add ("Password", "asdasd");
    data.Add ("CustNumber", "asdasdasd");
    data.Add ("Amount", "21231313");
    data.Add ("SessionId", sessionID.ToString ());
    data.Add ("UserDeclinedURL", encodedURL);
    data.Add ("UserApprovedURL", encodedURL);
    data.Add ("ServerURL", encodedURL);
				
    string response = System.Text.Encoding.UTF8.GetString (client.UploadValues ("URL", data));
				
