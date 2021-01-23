        private Dictionary<string, string> _name;
        public Dictionary<string, string> Name
        {
            get
            {
                if(_name == null)
                    _name = new Dictionary<string, string>();
                return _name;
            }
            set
            {
                _name = value;
            }
        }
