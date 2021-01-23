    public static class WebAccess
    {
        WebClient instance;
        public static WebClient GetWebClient()
        {
            if (instance == null)
               instance = new WebClient();
    
            return instance;
        }
    }
