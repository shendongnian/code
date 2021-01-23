    [AttributeUsage(AttributeTargets.Class)]
    class MyAttribute : Attribute
    {
        public Type CallingType { get; set; }
    
        public MyAttribute(Type type)
        {
           // heres your magic
           this.CallingType = type;
        }
    }
