    public class JoomlaUserManagement
    {
        private const string _USERCOM = "com_users";
        private const string _LOGINVIEW = "login";
        private const string _LOGINTASK = "user.login";
        private const string _REGEXTOKEN = "([a-zA-Z0-9]{32})";
        private const string _REGEXRETURN = "([a-zA-Z0-9]{27}=)";
        private const string _REGEXRETURNLOGOUT = "([a-zA-Z0-9]{52})";
        
        /// <summary>
        /// Gets the user name which is used to do the joomla login
        /// </summary>
        public String UserName { get; private set; }
        /// <summary>
        /// Gets the root uri to the joomla site.
        /// </summary>
        public Uri SiteRootUri { get; set; }
        /// <summary>
        /// Gets the last error occured when logging in
        /// </summary>
        public String LastError { get; private set; }
        private String _password { get; set; }
        private CookieAwareWebClient client;
        /// <summary>
        /// Initializes an instance for handling login or logoff
        /// </summary>
        /// <param name="userName">The username which is used to do the joomla login</param>
        /// <param name="password">The username which is used to do the joomla login</param>
        /// <param name="siteRoot">The root uri to the joomla site</param>
        public JoomlaUserManagement(String userName, String password, Uri siteRoot)
        {
            UserName = userName;
            _password = password;
            SiteRootUri = siteRoot;
            client = new CookieAwareWebClient();
        }
        
        /// <summary>
        /// Performs a joomla login.
        /// </summary>
        /// <returns>Returns true if succeeded. False if failed. If false, error will be written to <see cref="LastError"/></returns>
        public Boolean Login()
        {            
            NameValueCollection collection = new NameValueCollection();
            collection.Add("username", UserName);
            collection.Add("password", _password);
            collection.Add("option", _USERCOM);
            collection.Add("lang", "");
            collection.Add("view", _LOGINVIEW);
            // Request tokens.
            String token = null;
            String returnToken = null;
            byte[] result = client.UploadValues(SiteRootUri, "POST", collection);
            string resultingSource = Encoding.UTF8.GetString(result, 0, result.Length);
            
            Regex regex = new Regex(_REGEXTOKEN);
            Match match = regex.Match(resultingSource);            
            if (match.Success)            
                token = match.Value;
            regex = new Regex(_REGEXRETURN);
            match = regex.Match(resultingSource);
            if (match.Success)
                returnToken = match.Value;
            // Perform login
            if (returnToken != null && token != null)
            {
                collection.Add(token, "1");
                collection.Add("return", returnToken);
                collection.Add("task", "user.login");
                result = client.UploadValues(SiteRootUri, "POST", collection);
                resultingSource = Encoding.UTF8.GetString(result, 0, result.Length);
                // Invalid token?
                if (resultingSource.Length > 16)
                    return true;
                else
                {
                    LastError = "Unable to login.";
                    return false;
                }
            }
            else
            {
                // We don't have all tokens
                LastError = "Unable to retrieve tokens.";
                return false;
            }
        }
        
        public Boolean Logout()
        {            
            NameValueCollection collection = new NameValueCollection();
            collection.Add("username", UserName);
            collection.Add("password", _password);
            collection.Add("option", _USERCOM);
            collection.Add("lang", "");
            collection.Add("view", _LOGINVIEW);
            // Request tokens.
            String token = null;
            String returnToken = null;
            byte[] result = client.UploadValues(SiteRootUri, "POST", collection);
            string resultingSource = Encoding.UTF8.GetString(result, 0, result.Length);
            Regex regex = new Regex(_REGEXTOKEN);
            Match match = regex.Match(resultingSource);
            if (match.Success)
                token = match.Value;
            regex = new Regex(_REGEXRETURNLOGOUT);
            match = regex.Match(resultingSource);
            if (match.Success)
                returnToken = match.Value;
            // Perform login
            if (returnToken != null && token != null)
            {
                collection.Add(token, "1");
                collection.Add("return", returnToken);
                collection.Add("task", "user.logout");
                result = client.UploadValues(SiteRootUri, "POST", collection);
                resultingSource = Encoding.UTF8.GetString(result, 0, result.Length);
                // Invalid token?
                if (resultingSource.Length > 16)
                    return true;
                else
                {
                    LastError = "Unable to logout.";
                    return false;
                }
            }
            else
            {
                // We don't have all tokens
                LastError = "Unable to retrieve tokens.";
                return false;
            }
        }
    }
