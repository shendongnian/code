    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class XmlControlTypeAttribute : Attribute
    {
        protected Type xmlType;
      
        public XmlControlTypeAttribute(Type xmlType)
        {
            this.xmlType = xmlType;
        }
        public Type XmlType
        {
            get { return this.xmlType; }
        }
    }
