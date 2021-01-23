    class MyProviderInfo
    {
        public MyProviderInfo(Provider provider, string url)
        {
            Provider = provider;
            Url = url;
        }
    
        public Provider Provider
        {
            get;
            private set;
        }
    
        public string Url
        {
            get;
            private set;
        }
    }
