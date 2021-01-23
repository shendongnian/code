    public class Response
    {
        public string schema
        {
            get;
            set;
        }
    
        public ListingData data
        {
            get;
            set;
        }
    }
    
    public class ListingData
    {
        public string key
        {
            get;
            set;
        }
    
        public List<object> children
        {
            get;
            set;
        }
    }
    
    public class Type1
    {
        public string body
        {
            get;
            set;
        }
    
        public string parent_id
        {
            get;
            set;
        }
    
        public int report_count
        {
            get;
            set;
        }
    
        public string name
        {
            get;
            set;
        }
    }
    
    public class Type3
    {
        public string domain
        {
            get;
            set;
        }
    
        public bool flagged
        {
            get;
            set;
        }
    
        public string category
        {
            get;
            set;
        }
    
        public bool saved
        {
            get;
            set;
        }
    
        public string id
        {
            get;
            set;
        }
    
        public double created
        {
            get;
            set;
        }
    }
