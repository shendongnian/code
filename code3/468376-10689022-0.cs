    using Microsoft.BizTalk.Streaming;
    
    public class AddXmlNamespaceStream : XmlTranslatorStream
    {
        private String namespace_;
        private int level_ = 0; // hierarchy level
        public AddXmlNamespaceStream(Stream stream, String @namespace)
            : base(XmlReader.Create(stream))
        {
            namespace_ = @namespace;
        }
        #region XmlTranslatorStream Overrides
        protected override void TranslateStartElement(string prefix, string localName, string nsURI)
        {
            if (level_++ != 0)
            {
                base.TranslateStartElement(prefix, localName, nsURI);
                return;
            }
            if (String.IsNullOrEmpty(nsURI))
            {
                nsURI = namespace_;
                if (String.IsNullOrEmpty(prefix))
                    prefix = "__bts_ns0__";
            }
            base.TranslateStartElement(prefix, localName, nsURI);
        }
        protected override void TranslateEndElement(bool full)
        {
            if (level_-- != 0)
            {
                base.TranslateEndElement(full);
                return;
            }
            base.TranslateEndElement(full);
        }
        #endregion
    }
