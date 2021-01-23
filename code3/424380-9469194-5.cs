    class ConcreteClassWrapper
    {
        private ConcreteClass _cc;
        public ConcreteClassWrapper(ConcreteClass cc)
        {
            _cc = cc;
        }
        public string Name { get { return _cc.Name; } set { _cc.Name = value; } }
        public string MyProperty{ get { return _cc.MyProperty; } set { _cc.MyProperty = value; } }
        public int AdditionalProperty { get; set; } 
    }
