    public class Request
    {
        private int _typeId;
        public int TypeId 
        get
        {
            return _typeId;
        }
        set
        {
            isApproved = value != 1;
            _typeId = value;
        }
    
        public bool isApproved { get; set; }
    }
