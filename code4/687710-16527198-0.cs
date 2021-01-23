    public class Location
    {
        // You should have a public default constructor on all types for (de)sereialization.
        public Location()
        {
            this._namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] {
                new XmlQualifiedName(string.Empty, "urn:myNamespace"); // Default namespace -- prevents xsi:nil="true" from being generated, as well as xsd:* attributes.
            });
        }
        public string StreetAddress
        {
            // If you don't want <StreetAddress xsi:nil="true" /> to be generated, do this:
            get { return string.IsNullOrEmpty(this._streetAddress) ? null : this._streetAddress; }
            // Otherwise, if you don't care, just do
            // get;
            // Only need to implement setter if you don't want xsi:nil="true" to be generated.
            set { this._streetAddress = value; }
            // Otherwise, just
            // set;
        }
        private string _streetAddress;
        public Contact ContactInfo
        {
            // You must definitely do this to prevent the output of ContactInfo element
            // when it's null (i.e. contains no data)
            get
            {
                if (this._contactInfo != null && string.IsNullOrWhiteSpace(this._contactInfo.PhoneNumber) && string.IsNullOrWhiteSpace(this._contactInfo.EmailAddr))
                    return null;
                 return this._contactInfo;
            }
            set { this._contactInfo = value; }
        }
        private Contact _contactInfo;
        [XmlNamespacesDeclarations]
        public XmlSerializerNamespaces Namespaces
        {
            get { return this._namespaces; }
        }
        private XmlSerializerNamespaces _namespaces;
    }
