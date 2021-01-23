    public class MyViewModel : ISearchable{
        public List<Article> Articles { get; set; }
        
        #region ISearchable
        public SearchResult Search(string query){
            string title = "";
            string url = "";
            string description = "";
            int rank = 0;
            // Custom logic to search for an article
            ...
            return new SearchResult(title, url, description, rank);
        }
        #endregion
    }
