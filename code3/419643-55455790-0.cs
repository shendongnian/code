    [AttributeUsage(AttributeTargets.Property)]
    public class UsePropertyNameAsXmlElementAttribute : XmlElementAttribute
    {
        public UsePropertyNameAsXmlElementAttribute([CallerMemberName] string propertyName = null)
        : base(propertyName?.ToLower())
        {
        }
    }
