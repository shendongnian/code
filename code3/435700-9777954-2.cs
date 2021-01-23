    public static class WebClientFactory
    {
        public static WebClient Create()
        {
            WebClient result = new WebClient();
            result.Headers.Add("My Fancy User Agent");
            return result;
        }
    }
