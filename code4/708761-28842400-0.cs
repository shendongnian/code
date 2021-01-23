     public static partial class Ext
    {
        public static Uri GetUriWithparameters(this Uri uri,Dictionary<string,string> queryParams = null,int port = -1)
        {
            var builder = new UriBuilder(uri);
            builder.Port = port;
            if(null != queryParams && 0 < queryParams.Count)
            {
                var query = HttpUtility.ParseQueryString(builder.Query);
                foreach(var item in queryParams)
                {
                    query[item.Key] = item.Value;
                }
                builder.Query = query.ToString();
            }
            return builder.Uri;
        }
        public static string GetUriWithparameters(string uri,Dictionary<string,string> queryParams = null,int port = -1)
        {
            var builder = new UriBuilder(uri);
            builder.Port = port;
            if(null != queryParams && 0 < queryParams.Count)
            {
                var query = HttpUtility.ParseQueryString(builder.Query);
                foreach(var item in queryParams)
                {
                    query[item.Key] = item.Value;
                }
                builder.Query = query.ToString();
            }
            return builder.Uri.ToString();
        }
    }
