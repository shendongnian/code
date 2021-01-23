    public struct Config
    {
        private List<int> _ipAddress;
        private bool _isAssigned;
        public List<int> 
        {
            get 
            {
                if (!_isAssigned)
                    _ipAddress = new List<int>;
                return _ipAddress; 
            }
            set
            {
                _ipAddress = value;
                _isAssigned = true;
            }
        }
    }
