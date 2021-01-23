    public class CookieAwareWebClient : WebClient
    {
        public CookieContainer cookies = new CookieContainer();
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            var httpRequest = request as HttpWebRequest;
            if (httpRequest != null)
            {
                httpRequest.ProtocolVersion = HttpVersion.Version10;
                httpRequest.CookieContainer = cookies;
    
                var table = (Hashtable)cookies.GetType().InvokeMember("m_domainTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, cookies, new object[] { });
                var keys = new ArrayList(table.Keys);
                foreach (var key in keys)
                {
                    var newKey = (key as string).Substring(1);
                    table[newKey] = table[key];
                }
            }
            return request;
        }
    }
    
    var client = new CookieAwareWebClient();
    
    var loginData = new NameValueCollection();
    loginData.Add("usrname", "test");
    loginData.Add("pass", "123");
    loginData.Add("nopass_email", "Type in your e-mail and press enter");
    loginData.Add("nopass", "0");
    // Hack: Authenticate the user twice!
    var results = client.UploadValues(@"http://wallbase.cc/user/login", "POST", loginData);
    results = client.UploadValues(@"http://wallbase.cc/user/login", "POST", loginData);
    
    var success = client.DownloadString("http://wallbase.cc/home/");
