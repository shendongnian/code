    public static class SearchResultHelper
    {
        public static string GetValue(this SearchResult searchResult, string propertyName)
        {
            return SearchResult.Properties.Contains(propertyName) ? SearchResult.Properties[propertyName][0].ToString() 
        }
    }
