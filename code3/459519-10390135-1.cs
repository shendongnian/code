    MyClass myClass = new MyClass();
    class MyClass
    {
        public MyClass()
        {
            _MyProperty = new List<string>();
            _MyProperty.Add("Test 1");
            _MyProperty.Add("Test 2");
        }
        private List<string> _MyProperty;
        public System.Collections.ObjectModel.ReadOnlyCollection<string> MyProperty 
        {
            get { return _MyProperty.AsReadOnly(); }
        }        
    }
