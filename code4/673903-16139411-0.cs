    WebProxy[] myproxies = new WebProxy[] { new WebProxy("1.1.1.1", 80), 
         new WebProxy("1.1.1.2", 80) };
    var currentProxy = 0;
    while (true)
    {
       // set proxy to new one every iteration...
       currentProxy = (currentProxy + 1) % myproxies.Length;
       using (WebClient wc = new WebClient())
       {
         wc.Proxy = myproxies[currentProxy]; 
         wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
         string HtmlResult = wc.UploadString(URI, params);
       }
    }
