    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    sealed class MyAttribute : Attribute
    {
        public MyAttribute()
        {
        }
    }
    
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    sealed class MyAttribute1 : Attribute
    {
        public MyAttribute1()
        {
        }
    }
    
    class Class1
    {
        [MyAttribute()]
        public virtual string test { get; set; }
    }
    
    class Class2 : Class1
    {
        [MyAttribute1()]
        public override string test
        {
            get { return base.test; }
            set { base.test = value; }
        }
    }
