    class Person : IPerson
    {
        public IContact contact 
        { 
            get
            {
                // This initializes the property if it is null. 
                // That way, anytime you access the property "contact" in your code, 
                // it will check to see if it is null and initialize if needed.
                if(_contact == null)
                {
                    _contact = new Contact();
                }
                return _contact;
            } 
            set
            {
                _contact = value;
            } 
        }
        private IContact _contact;
    }
