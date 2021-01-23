    public static class HttpRequestExtensions
    {
        public static String RemoveTrailingChars(this HttpRequest request, int charsToRemove)
        {
            // Reconstruct the url including any query string parameters
            String url = (request.Url.Scheme + "://" + request.Url.Authority + request.Url.AbsolutePath);
                
            return (url.Length > charsToRemove ? url.Substring(0, url.Length - charsToRemove) : url) + request.Url.Query;
        }
    }
