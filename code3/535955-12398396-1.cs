    class Bookmark
    {
        private string baseUrl;
        public string BaseUrl
        {
            get
            {
                return baseUrl;
            }
            set
            {
                baseUrl = GetDomainFromUrl(value));
            }
        }
        private string GetDomainFromUrl(string url)
        {
            //your logic to generate BaseUrl
        }
    }
