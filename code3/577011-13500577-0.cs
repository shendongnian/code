    # Main function
    NameValueCollection postData = new NameValueCollection();  
    postData.Add("username", "abcd");
    postData.Add("password", "efgh");
    
    var wc = new CookieAwareWebClient();
    var uri = new Uri("https://abcd.example.com/service/login/");
    var servicePoint = ServicePointManager.FindServicePoint(uri);
    servicePoint.Expect100Continue = false;
    wc.DownloadString(uri);
    Console.WriteLine(wc.ResponseHeaders);
    byte[] results = wc.UploadValues(uri, postData);
    string text = System.Text.Encoding.ASCII.GetString(results);
    Console.WriteLine(text);
