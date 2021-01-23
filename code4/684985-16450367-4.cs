    class Human
    {     
        private string _name = "";
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(_name))
                    _name = value;
                else  
                    _name = value.Substring(0, 1).ToUpper() + _value.Substring(1);
            }
        }
    }
