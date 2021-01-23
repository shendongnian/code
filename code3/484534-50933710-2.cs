    public static class UriExtensions
    {
        public static Uri DropQueryItem(this Uri u, string key)
        {
            UriBuilder b = new UriBuilder(u);
            b.RemoveQueryItem(key);
            return b.Uri;
        }
    }
    public static class UriBuilderExtensions
    {
        private static string _ParseQueryPattern = @"(?<key>[^&=]+)={0,1}(?<value>[^&]*)";
        private static Regex _ParseQueryRegex = null;
        private static Regex ParseQueryRegex
        {
            get
            {
                if (_ParseQueryRegex == null)
                {
                    _ParseQueryRegex = new Regex(_ParseQueryPattern, RegexOptions.Compiled | RegexOptions.Singleline);
                }
                return _ParseQueryRegex;
                
            }
        }
        public static void SetQueryItem(this UriBuilder b, string key, string value)
        {
            NameValueCollection parms = ParseQueryString(b.Query);
            parms[key] = value;
            b.Query = RenderQuery(parms);
        }
        public static void RemoveQueryItem(this UriBuilder b, string key)
        {
            NameValueCollection parms = ParseQueryString(b.Query);
            parms.Remove(key);
            b.Query = RenderQuery(parms);
        }       
        private static string RenderQuery(NameValueCollection parms)
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i<parms.Count; i++)
            {
                string key = parms.Keys[i];
                sb.Append(key + "=" + parms[key]);
                if (i < parms.Count - 1)
                {
                    sb.Append("&");
                }
            }
            return sb.ToString();
        }
        public static NameValueCollection ParseQueryString(string query, bool caseSensitive = true)
        {
            NameValueCollection pairs = new NameValueCollection(caseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase);
            string q = query.Trim().TrimStart(new char[] {'?'});
            MatchCollection matches = ParseQueryRegex.Matches(q);
            foreach (Match m in matches)
            {
                string key = m.Groups["key"].Value;
                string value = m.Groups["value"].Value;
                if (pairs[key] != null)
                {
                    pairs[key] = pairs[key] + "," + value;
                }
                else
                {
                    pairs[key] = value;
                }
            }
            return pairs;
        }
    }
