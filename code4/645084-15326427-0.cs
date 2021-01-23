    public class Search:ISearch
    {
        private static readonly string url = "http://www.google.com/search";
        private readonly IWebRequestCreator _generator;
    
        public Search(IWebRequestCreator generator)
        {
            _generator = generator;
        }
    
        public Result SendSearch(string query)
        {
            var queryUrl = string.Format("{0}?q={1}", url, query);
            var webRequest = _generator.Create(queryUrl);
            // ...
        }
    }
