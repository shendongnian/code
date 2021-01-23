    using System;
    using System.Security.Cryptography.Xml;
    using System.Xml;
    namespace CustomSecurity
    {
    [Serializable]
    internal class SecurityTokenReference : KeyInfoClause
    {
        // CAntonio. Simple class that allow us to create a Security Token Reference that will be provided as part of the soap request.
        private string m_id;
        private XmlDocument m_doc;
        private KeyInfoX509Data m_keyX509Data = new KeyInfoX509Data();
        public SecurityTokenReference(string id, XmlDocument doc)
        {
            m_id = id;
            m_doc = doc;
        }
        public override XmlElement GetXml()
        {
            XmlElement element = m_doc.CreateElement("wsse", "SecurityTokenReference", CustomSignedXml.xmlOasisWSSSecurityExtUrl);
            XmlAttribute idAttrib = m_doc.CreateAttribute("wsu", "Id", CustomSignedXml.xmlOasisWSSSecurityUtilUrl);
            idAttrib.Value = m_id;
            element.Attributes.Append(idAttrib);
            // Get the Key Info, that should be inside STR
            XmlElement key509 = m_keyX509Data.GetXml(); // It may be good that we were able to use GetXml(doc)
            XmlDsigDocument.SetPrefix(XmlDsigDocument.XmlDsigNamespacePrefix, key509);
            XmlElement x509DataElement = m_doc.CreateElement(XmlDsigDocument.XmlDsigNamespacePrefix, "X509Data", SignedXml.XmlDsigNamespaceUrl);
            x509DataElement.InnerXml = key509.InnerXml;
            element.AppendChild(x509DataElement);
            return element;
        }
        public KeyInfoX509Data KeyX509Data { get { return m_keyX509Data; } }
        public override void LoadXml(XmlElement element)
        {
            // just copy ID into our member variable...
            m_id = element.GetAttribute("Id", CustomSignedXml.xmlOasisWSSSecurityUtilUrl);
            // We may load KeyX509Data, but we don't need it...
        }
    }
    }
