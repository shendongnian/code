    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueAttribute : System.Attribute 
    {
        public readonly string _value;
        public string Value
        {
            get
            {
                return _value;
            }
        }
        public HelpAttribute(string value)  // value is a positional parameter
        {
            //beware: value can be null...
            // ...but we don't want to throw exceptions here
            _value = value;
        }
    }
