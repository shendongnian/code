    public class Request
    {
        private int _typeId;
        public int TypeId { 
            get { return _typeId; }
            set {
                _typeId = value;
                isApproved = _typeId != 1;
            }
        }
        public bool isApproved { get; private set; }
    }
