    public static class UriExtensions
    {
        public static string GetUsername(this Uri uri)
        {
            if (uri == null || string.IsNullOrWhiteSpace(uri.UserInfo))
                return string.Empty;
    
            var items = uri.UserInfo.Split(new[] { ':' });
            return items.Length > 0 ? items[0] : string.Empty;
        }
    
        public static string GetPassword(this Uri uri)
        {
            if (uri == null || string.IsNullOrWhiteSpace(uri.UserInfo))
                return string.Empty;
    
            var items = uri.UserInfo.Split(new[] { ':' });
            return items.Length > 1 ? items[1] : string.Empty;
        }
    }
