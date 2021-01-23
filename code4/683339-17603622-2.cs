    public static class HttpCookieCollectionExtensions
    {
        public static HttpCookie GetOrCreateCookie(this HttpCookieCollection collection, string name)
        {
            // Check if the key exists in the cookie collection. We check manually so that the Get
            // method doesn't implicitly add the cookie for us if it's not found.
            var keyExists = collection.AllKeys.Any(key => string.Equals(name, key, StringComparison.OrdinalIgnoreCase));
            if (keyExists) return collection.Get(name);
            // The cookie doesn't exist, so add it to the collection.
            var cookie = new HttpCookie(name);
            collection.Add(cookie);
            return cookie;
        }
    }
