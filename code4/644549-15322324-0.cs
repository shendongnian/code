    public string Scrap(string Username, string Password)
        {
            string Url1 = "https://www.example.com";//first url
            string Url2 = "https://www.example.com/login.aspx";//secret url to post request to
            //first request
            CookieContainer jar = new CookieContainer();
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(Url1);
            request1.CookieContainer = jar;
            //Get the response from the server and save the cookies from the first request..
            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
            
            //second request
            string postData = "***viewstate here***";//VIEWSTATE
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(Url2);
            request2.CookieContainer = jar;
            request2.KeepAlive = true;
            request2.Referer = Url2;
            request2.Method = WebRequestMethods.Http.Post;
            request2.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request2.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            request2.ContentType = "application/x-www-form-urlencoded";
            request2.AllowWriteStreamBuffering = true;
            request2.ProtocolVersion = HttpVersion.Version11;
            request2.AllowAutoRedirect = true;
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            request2.ContentLength = byteArray.Length;
            Stream newStream = request2.GetRequestStream(); //open connection
            newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
            newStream.Close();
            
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            using (StreamReader sr = new StreamReader(response2.GetResponseStream()))
            {
                responseData = sr.ReadToEnd();
            }
            return responseData;
        }
