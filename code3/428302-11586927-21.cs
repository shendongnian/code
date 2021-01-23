    var client = new CookieAwareWebClient();
    client.UseDefaultCredentials = true;
    client.BaseAddress = @"http://wallbase.cc";
    
    var loginData = new NameValueCollection();
    loginData.Add("usrname", "test");
    loginData.Add("pass", "123");
    //loginData.Add("nopass_email", "Type in your e-mail and press enter");
    //loginData.Add("nopass", "0");
    client.UploadValues(@"http://wallbase.cc/user/login", "POST", loginData);
    
    // Get Response.
    string response = client.DownloadString("http://wallbase.cc/home/");
