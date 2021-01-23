    public class DataSet
    {
        public IDictionary<string, MyClass1> Property { get; private set; }    
    
        public DataSet()
        {
            Property = LoadProperty();
        }
    }
