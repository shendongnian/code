        public XElement XmlValueWrapper
        {
            get { return XmlContent != null ? XElement.Parse(XmlContent) : null; }
            set { XmlContent = value.ToString(); }
        }
