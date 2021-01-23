    public class ApiClient
    {
        public ApiClient(string magentoServer, string consumerKey, string consumerSecret, string accessToken, string accessTokenSeccret)
        {
            MagentoServer = magentoServer;
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSeccret;
        }
        #region Request
        HttpWebRequest CreateAuthorizedRequest(string url, string requestMethod,ApiFilter filter)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + filter.ToString());
            OAuthBase oAuth = new OAuthBase();
            string nonce = oAuth.GenerateNonce();
            string timeStamp = oAuth.GenerateTimeStamp();
            string parameters;
            string normalizedUrl;
            string signature = oAuth.GenerateSignature(new Uri(url), ConsumerKey, ConsumerSecret,
            AccessToken, AccessTokenSecret, requestMethod, timeStamp, nonce, OAuthBase.SignatureTypes.PLAINTEXT,
            out normalizedUrl, out parameters);
            StringBuilder sb = new StringBuilder("OAuth ");
            sb.AppendFormat("oauth_token=\"{0}\",", AccessToken);
            sb.AppendFormat("oauth_version=\"{0}\",", "1.0");
            sb.AppendFormat("oauth_signature_method=\"{0}\",", "PLAINTEXT");
            sb.AppendFormat("oauth_nonce=\"{0}\",", nonce);
            sb.AppendFormat("oauth_timestamp=\"{0}\",", timeStamp);
            sb.AppendFormat("oauth_consumer_key=\"{0}\",", ConsumerKey);
            sb.AppendFormat("oauth_signature=\"{0}\"", signature);
            request.Headers[HttpRequestHeader.Authorization] = sb.ToString();
            request.Method = requestMethod;
            //request.ContentType = "application/json";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";//application/json,
            request.KeepAlive = true;
            return request;
        }
        string FetchRequest(HttpWebRequest request)
        {
            try
            {
                string responseText = string.Empty;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            responseText = responseReader.ReadToEnd();
                            return responseText;
                        }
                    }
                }
                return responseText;
            }
            catch (WebException ex)
            {
                var responseStream = ex.Response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);
                string responseText = responseReader.ReadToEnd();
                throw new MagentoApiException(responseText,ex.Status);
            }
        }
        #endregion
        #region Public properties
        string MagentoServer { get; set; }
        string ConsumerKey { get; set; }
        string ConsumerSecret { get; set; }
        string AccessToken { get; set; }
        string AccessTokenSecret { get; set; }
        #endregion
    }
    public class ApiFilter
    {
        public ApiFilter()
        {
            filterDescriptions = new List<FilterDescription>();
        }
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public List<FilterDescription> filterDescriptions;
        public const string Type = "rest";
        public void AddFilter(string column, FilterType filterType, string value)
        {
            filterDescriptions.Add(new FilterDescription()
            {
                Column = column,
                FilterType = filterType,
                Value = value
            });
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("type={0}", Type);
            if (Page.HasValue)
                sb.AppendFormat("&page={0}", Page.Value);
            if (Limit.HasValue)
                sb.AppendFormat("&limit={0}", Limit.Value);
            int counter = 1;
            foreach (var filter in filterDescriptions)
            {
                sb.AppendFormat("&filter[{0}][attribute]={1}&filter[{2}][{3}]={4}", counter, filter.Column, counter, filter.FilterType, filter.Value);
                counter++;
            }
            return sb.ToString();
        }
    }
    public class FilterDescription
    {
        public string Column { get; set; }
        public FilterType FilterType { get; set; }
        public string Value { get; set; }
    }
    public enum FilterType
    {
        /// <summary>
        /// Not Equal To
        /// </summary>
        neq,
        /// <summary>
        /// equals any of
        /// </summary>
        @in,
        /// <summary>
        /// not equals any of
        /// </summary>
        nin,
        /// <summary>
        /// greater than
        /// </summary>
        gt,
        /// <summary>
        /// less than
        /// </summary>
        lt
    }
    public class MagentoApiException : Exception
    {
        public MagentoApiException(string responseText, WebExceptionStatus status)
        {
            ResponseText = responseText;
            Status = status;
        }
        public string ResponseText { get; set; }
        public WebExceptionStatus Status { get; set; }
    }
