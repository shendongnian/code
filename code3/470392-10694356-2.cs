    private static void TestService()
    {
        try
        {
            string loginAddress = "<login url>";
            string serviceAddress = "<service url>";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(loginAddress);
            req.Method = "POST";
            string userName = "<user>";
            string password = "<password>";
            CookieContainer cc = new CookieContainer();
            req.CookieContainer = cc;
    
            StringBuilder sb = new StringBuilder();
            sb.Append(@"__VIEWSTATE=<viewstate>");
            sb.Append(@"&__EVENTVALIDATION=<event validation>");
            sb.Append(@"&ctl00$MainContent$LoginUser$UserName={0}&ctl00$MainContent$LoginUser$Password={1}");
            sb.Append(@"&ctl00$MainContent$LoginUser$LoginButton=Log In");
            string postData = sb.ToString();
            postData = String.Format(postData, userName, password);
            req.ContentType = "application/x-www-form-urlencoded";
            Encoding encoding = new ASCIIEncoding();
            byte[] requestData = encoding.GetBytes(postData);
            req.ContentLength = requestData.Length;
    
            //write the post data to the request
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(requestData, 0, requestData.Length);
                reqStream.Flush();
            }
            
            HttpWebResponse response = (HttpWebResponse)req.GetResponse(); //first call (login / authentication)
    
            req = (HttpWebRequest)WebRequest.Create(serviceAddress);
            req.CookieContainer = cc; //set the cookie container which contains the auth cookie
            response = (HttpWebResponse)req.GetResponse(); //second call, the service request
            Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            Console.WriteLine(s);
        }
        catch (WebException ex)
        {
            Console.WriteLine(ex.Message);
            if (ex.Response != null)
            {
                Stream strm = ex.Response.GetResponseStream();
                byte[] bytes = new byte[strm.Length];
                strm.Read(bytes, 0, (int)strm.Length);
                string sResponse = System.Text.Encoding.ASCII.GetString(bytes);
                Console.WriteLine(sResponse);
            }
        }
    }
