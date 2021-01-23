    var client = new CookieAwareWebClient();
    client.UseDefaultCredentials = true;
    client.BaseAddress = @"http://wallbase.cc";
    
    var loginData = new NameValueCollection();
    loginData.Add("usrname", "test");
    loginData.Add("pass", "123");
    loginData.Add("nopass_email", "Type in your e-mail and press enter");
    loginData.Add("nopass", "0");
    var result = client.UploadValues(@"http://wallbase.cc/user/login", "POST", loginData);
    
    string response = System.Text.Encoding.UTF8.GetString(result);
