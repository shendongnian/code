    public class MyClass
    {
        ...
        
        [TypeConverter(typeof(MyStringConverter))]
        public string MyProp { get; set; }
        
        ...
    }
