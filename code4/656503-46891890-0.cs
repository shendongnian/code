    public static class UriExtensions
     {                   
        public static Uri AttachParameters(this Uri uri, 
                                           NameValueCollection parameters)
        {
            var stringBuilder = new StringBuilder();
            string str = "?";
            for (int index = 0; index < parameters.Count; ++index)
            {
                stringBuilder.Append(str + 
                    System.Net.WebUtility.UrlEncode(parameters.AllKeys[index]) +
                     "=" + System.Net.WebUtility.UrlEncode(parameters[index]));
                str = "&";
            }
            return new Uri(uri + stringBuilder.ToString());
        }
        public static string GetBaseUrl(this Uri uri) {
            string baseUrl = uri.Scheme + "://" + uri.Host;
            return baseUrl;
        }
        public static string GetBaseUrl_Path(this Uri uri) {
            string baseUrl = uri.Scheme + "://" + uri.Host + uri.AbsolutePath;
            return baseUrl;
        }
     }
