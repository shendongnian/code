    public class DisplayStringAttribute : Attribute
    {
        private readonly string value;
        public string Value
        {
            get { return value; }
        }
        public DisplayStringAttribute(string val)
        {
            value = val;
        }
    }
