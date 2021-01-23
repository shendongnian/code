    class MyObject
    {
        // static members are common to all instances
        static string DefaultProperty1 = "Some Default";
    
        private string _Property1;
        public string Property1
        {
            get
            {
                // If the backing field is NULL, return the default
                if (_Property1 == null)
                    return DefaultProperty1;
                // Otherwise, return the per-instance value
                return _Property1;
            }
            set { _Property1 = value; }
        }
    }
