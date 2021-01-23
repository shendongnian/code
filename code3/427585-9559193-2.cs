    [AttributeUsage(AttributeTargets.Property)]
    public class MapToAttribute : Attribute
    {
        public string XPathSelector { get; private set; }
        public MapToAttribute(string xPathSelector)
        {
            XPathSelector = xPathSelector;
        }
    }
