    class ConcreteClass : BaseClass
    {
        public int MyProperty { get; set; }
        
        public ConcreteClass(ConcreteClass copy)
        {
            this.MyProperty = copy.MyProperty;
        }
    }
    class ConcreteClassWrapper : ConcreteClass
    {
        public int AdditionalProperty { get; set; }
        public ConcreteClassWrapper(ConcreteClass cc)
            base(cc)
        {
        }
    }
