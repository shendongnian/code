    public class SearchResult{
        SearchResult(string title, string url, string description, int rank){
            this.Title = title;
            this.Url = url;
            this.Description = description;
            this.Rank = rank;
        }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
    }
