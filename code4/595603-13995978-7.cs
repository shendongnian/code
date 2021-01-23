    public class SearchFieldViewModel
    {
        public string SearchString { get; set; }
        public SearchStrategy SearchStrategy { get; set; }
        
        public TipViewModel TipViewModel
        {
            get
            {
                return new TipViewModel
                {
                    SearchString = this.SearchString,
                    SearchStrategy = this.SearchStrategy
                };
            }
        }
    }
