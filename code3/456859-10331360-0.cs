    // This is the class we are going to add to a List
    public class DynamicClass
    {
        // property is a class that will create dynamic properties at runtime
        private DynamicProperty _property = new DynamicProperty();
        public DynamicProperty property
        {
            get { return _property; }
            set { _property = value; }
        }
    }
    public class DynamicProperty
    {
        // a Dictionary that hold all the dynamic property values
        private Dictionary<string, object> properties = new Dictionary<string, object>();
        // the property call to get any dynamic property in our Dictionary, or "" if none found.
        public object this[string name]
        {
            get
            {
                if (properties.ContainsKey(name))
                {
                    return properties[name];
                }
                return "";
            }
            set
            {
                properties[name] = value;
            }
        }
    }
