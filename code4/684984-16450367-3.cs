    class Human
    {     
        private string _name;
        public String Name
        {
            get
            {
                if (_name == null)
                    return null;
                if (_name.Length <= 1)
                    return _name.ToUpper() + _name.Substring(1);
                return _name.Substring(0, 1).ToUpper() + _name.Substring(1);
            }
            set
            {
                _name = value;
            }
        }
    }
