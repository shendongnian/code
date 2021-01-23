    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class authenticationResponse
    {
        private byte[] accountsField;
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("AccountId", IsNullable = false)]
        public byte[] Accounts
        {
            get
            {
                return this.accountsField;
            }
            set
            {
                this.accountsField = value;
            }
        }
    }
