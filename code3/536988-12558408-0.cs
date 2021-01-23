    public class IdentifierXmlWriter : XmlTextWriter
    {
        private bool isIdentifier = false;
        private bool isName = false;
        private bool isDescription = false;
        private readonly string identifierElementName;
        private readonly string nameElementName;
        private readonly string descElementName;
        public IdentifierXmlWriter(TextWriter w) : base(w)
        {
            Type identitierType = typeof (Identifier);
            identifierElementName = (identitierType.GetCustomAttributes(typeof(XmlElementAttribute), true).FirstOrDefault() as XmlElementAttribute ?? new XmlElementAttribute("Identifier")).ElementName;
            nameElementName = (identitierType.GetProperty("Name").GetCustomAttributes(typeof(XmlElementAttribute), true).FirstOrDefault() as XmlElementAttribute ?? new XmlElementAttribute("Name")).ElementName;
            descElementName = (identitierType.GetProperty("Description").GetCustomAttributes(typeof(XmlElementAttribute), true).FirstOrDefault() as XmlElementAttribute ?? new XmlElementAttribute("Description")).ElementName;
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            // If Identifier, set flag and ignore.
            if (localName == identifierElementName)
            {
                isIdentifier = true;
            }
            // if inside Identifier and first occurance of Name, set flag and ignore.  This will be called back with the element name in the Name's Value write call
            else if (isIdentifier && !isName && !isDescription && localName == this.nameElementName)
            {
                isName = true;
            }
            // if inside Identifier and first occurance of Description, set flag and ignore
            else if (isIdentifier && !isName && !isDescription && localName == this.descElementName)
            {
                isDescription = true;
            }
            else
            {
                // Write the element
                base.WriteStartElement(prefix, localName, ns);
            }
        }
        public override void WriteString(string text)
        {
            if ( this.isIdentifier && isName )
                WriteStartElement(text);            // Writing the value of the Name property - convert to Element
            else
                base.WriteString(text);
        }
        public override void WriteEndElement()
        {
            // Close element from the Name property - Ignore
            if (this.isIdentifier && this.isName)
            {
                this.isName = false;
                return;
            }
            // Cliose element from the Description - Closes element started with the Name value write
            if (this.isIdentifier && this.isDescription)
            {
                base.WriteEndElement();
                this.isDescription = false;
                return;
            }
            // Close element of the Identifier - Ignore and reset
            if ( this.isIdentifier )
            {
                this.isIdentifier = false;
            }
            else
                base.WriteEndElement();
        }
    }
            List<Identifier> identifiers = new List<Identifier>()
                                               {
                                                   new Identifier() { Name = "somename", Description = "somedescription"},
                                                   new Identifier() { Name = "anothername", Description = "anotherdescription"},
                                                   new Identifier() { Name = "Name", Description = "Description"},
                                               };
