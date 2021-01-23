        private Dictionary<string, sting> _name;
        public Dictionary<string, string> Name
        {
            get
            {
                if(_name == null)
                    _name = new Dictionary<string, string>();
                return name;
            }
            set
            {
                name = value;
            }
        }
