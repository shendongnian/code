    System.Net.ServicePointManager.Expect100Continue = false;
    var client = new CookieAwareWebClient();
    client.BaseAddress = @"http://wallbase.cc/user/login";
    var loginData = new NameValueCollection();
    loginData.Add("loginform", "login");
    loginData.Add("login_username", "TEST");
    loginData.Add("login_pass", "123");
    client.UploadValues(@"http://wallbase.cc/user/login", "POST", loginData);
    
    // Get Response.
    string response = client.DownloadString("http://wallbase.cc/home/");
