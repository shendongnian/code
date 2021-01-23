    public class SearchModel
    {
        private List<TagDetails> _tags;
    
        public SearchModel()
        {
            _tags = new List<TagDetails>();
        }
    
        public IEnumerable<TagDetails> Tags {get {return _tags;}}
    
    }
