    public class MyClass
    {
        public Func<DesiredType> ValueGetter {get;set;}
        public DesiredType Value { get { return ValueGetter(); } }
    }
