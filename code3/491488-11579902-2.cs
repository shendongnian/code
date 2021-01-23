    public partial class DataEventSet 
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces _xmlns;
        /// <summary>
        /// Constructor for DataEventSet that sets up default namespaces
        /// </summary>
        public DataEventSet()
        {
            _xmlns = new XmlSerializerNamespaces();
            _xmlns.Add("", "http://www.thirdparty.org/thirdapp");
            _xmlns.Add("o", "http://www.thirdparty.org/thirdapp");
        }
    }
