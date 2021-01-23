    class Bookmark
    {
        public string BaseUrl { get; }
        public Bookmark(string url)
        {
            BaseUrl = GetDomainFromUrl(url);
        }
        private string GetDomainFromUrl(string url)
        {
            //your logic to generate BaseUrl
        }
    }
