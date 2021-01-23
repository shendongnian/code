    [AttributeUsage(AttributeTargets.Property)]
    public class UsePropertyNameToLowerAsXmlElementAttribute: XmlElementAttribute
    {
        public UsePropertyNameToLowerAsXmlElementAttribute([CallerMemberName] string propertyName = null)
        : base(propertyName?.ToLower())
        {
        }
    }
