    public static class UriExtensions
    {
        public static Uri DropQueryItem(this Uri u, string key)
        {
            UriBuilder b = new UriBuilder(u);
            b.RemoveQueryItem(key);
            return b.Uri;
        }
    }
