    public class XmlTextWriterFull : XmlTextWriter
    {
        public XmlTextWriterFull(TextWriter sink)
            : base(sink)
        {
            Formatting = Formatting.Indented;
        }
    
        private bool inElement = false;
    
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(prefix, localName, ns);
    
            // Remember that we're in the process of defining an element.
            // As soon as a child element is closed, this flag won't be true anymore and we'll know to avoid messing with the indenting.
            this.inElement = true;
        }
    
        public override void WriteEndElement()
        {
            if (!this.inElement)
            {
                // The element being closed has child elements, so we should just let the writer use it's default behavior.
                base.WriteEndElement();
            }
            else
            {
                // It looks like the element doesn't have children, and we want to avoid emitting a self-closing tag.
                // First, let's temporarily disable any indenting, then force the full closing element tag.
                var prevFormat = this.Formatting;
                this.Formatting = Formatting.None;
                base.WriteFullEndElement();
                this.Formatting = prevFormat;
                this.inElement = false;
            }
        }
    }
