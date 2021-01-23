    public class DataSet
    {
        private IDictionary<string, MyClass> property;
    
        public IDictionary<string, MyClass> Property
        {
            if (property == null)
            {
                property = LoadProperty();
            }
            return property;
        }
    }
