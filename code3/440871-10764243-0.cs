    public class FacebookHelper
    {
        private string _appId;
        private string _appSecret;
        private string _accessToken;
        public string AccessToken
        {
            get
            {
                if (_accessToken == null)
                    GetAccessToken();
                return _accessToken;
            }
            set { _accessToken = value; }
        }
        public FacebookHelper(string appId, string appSecret)
        {
            this._appId = appId;
            this._appSecret = appSecret;
        }
        public string GetAccessToken()
        {
            var facebookCookie = HttpContext.Current.Request.Cookies["fbsr_" + _appId];
            if (facebookCookie != null && facebookCookie.Value != null)
            {
                string jsoncode = System.Text.ASCIIEncoding.ASCII.GetString(FromBase64ForUrlString(facebookCookie.Value.Split(new char[] { '.' })[1]));
                var tokenParams = HttpUtility.ParseQueryString(GetAccessToken((string)JObject.Parse(jsoncode)["code"]));
                _accessToken = tokenParams["access_token"];
                return _accessToken;
            }
            else
                return null;
           // return DBLoginCall(username, passwordHash, cookieToken, cookieTokenExpires, args.LoginType == LoginType.Logout, null);
        }
        private string GetAccessToken(string code)
        {
            //Notice the empty redirect_uri! And the replace on the code we get from the cookie.
            string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", _appId, "", _appSecret, code.Replace("\"", ""));
            System.Net.HttpWebRequest request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
            System.Net.HttpWebResponse response = null;
            using (response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
                string retVal = reader.ReadToEnd();
                return retVal;
            }
        }
        private byte[] FromBase64ForUrlString(string base64ForUrlInput)
        {
            int padChars = (base64ForUrlInput.Length % 4) == 0 ? 0 : (4 - (base64ForUrlInput.Length % 4));
            StringBuilder result = new StringBuilder(base64ForUrlInput, base64ForUrlInput.Length + padChars);
            result.Append(String.Empty.PadRight(padChars, '='));
            result.Replace('-', '+');
            result.Replace('_', '/');
            return Convert.FromBase64String(result.ToString());
        }
    }
