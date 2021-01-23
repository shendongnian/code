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
