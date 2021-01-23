        CookieContainer cc = new CookieContainer();
        string getUrl = "somesite.com";
        
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getUrl);
        request.CookieContainer = cc;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string getUrl2 = "somepage.login.com";
        string postData = String.Format("username={0}&userpassword={1}", "foo", "foofoo");
        HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(getUrl2);
        getRequest.CookieContainer = cc;
        getRequest.Method = WebRequestMethods.Http.Post;
        getRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
        getRequest.AllowWriteStreamBuffering = true;
        getRequest.ProtocolVersion = HttpVersion.Version11;
        getRequest.AllowAutoRedirect = true;
        getRequest.ContentType = "application/x-www-form-urlencoded";
        byte[] byteArray = Encoding.ASCII.GetBytes(postData);
        getRequest.ContentLength = byteArray.Length;
        Stream newStream = getRequest.GetRequestStream(); 
        newStream.Write(byteArray, 0, byteArray.Length); 
        newStream.Close();
        HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
        using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
        {
            string sourceCode = sr.ReadToEnd();
        }
        //untill here it works fine i'm logged in....
        HttpWebRequest getRequest2 = (HttpWebRequest)WebRequest.Create("a page on the site..");
        getRequest2.CookieContainer = cc;
        HttpWebResponse getResponse2 = (HttpWebResponse)getRequest2.GetResponse();
        using (StreamReader sr = new StreamReader(getResponse2.GetResponseStream()))
        {
            string sourceCode = sr.ReadToEnd();
        }
        //here it rediects me to login page
