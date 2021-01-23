    public class UriBuilderExt
    {
        private NameValueCollection collection;
        private UriBuilder builder;
    
        public UriBuilderExt(string uri)
        {
            builder = new UriBuilder(uri);
            collection = System.Web.HttpUtility.ParseQueryString(string.Empty);
        }
    
        public void AddParameter(string key, string value) {
            collection.Add(key, value);
        }
    
        public Uri Uri{
            get
            {
                builder.Query = collection.ToString();
                return builder.Uri;
            }
        }
    
    }
