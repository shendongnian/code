    public class Criteria
    {
        public decimal? ANullableNumber { get; set; }
        private IList<ObjectInList> _objectsList = new List<ObjectInList>();
        public IList<ObjectInList> ObjectsList 
        { 
            get { return _objectsList; } 
            set { 
                if(value != null) 
                    _objectsList = value;
            }
         }
    }
