    using System;
    using System.Xml;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Reflection;
    namespace CustomSecurity
    {
    //  Subclass System.Security.Cryptography.Xml.SignedXml to handle situations
    //  where the signed XML element has an attribute named id instead of Id.
    // Public Class SignedXML : System.Security.Cryptography.Xml.SignedXml
    public class CustomSignedXml : SignedXml
    {
        public CustomSignedXml()
            : base()
        {
        }
        public CustomSignedXml(XmlDocument doc)
            : base(doc)
        {
        }
        public CustomSignedXml(XmlElement elem)
            : base(elem)
        {
        }
        // Summary:
        //     Represents the Uniform Resource Identifier (URI) for the soap envelope description
        //     transformation. This field is constant.
        public const string xmlSoapEnvelopeUrl = "http://schemas.xmlsoap.org/soap/envelope/";
        // Summary:
        //     Represents the Uniform Resource Identifier (URI) for the soap security description
        //     transformation. This field is constant.
        public const string xmlSoapSecurityUrl = "http://schemas.xmlsoap.org/soap/security/2000-12";
        // Summary:
        //     Represents the Uniform Resource Identifier (URI) for the wss utility namespace
        //     transformation. This field is constant.
        public const string xmlOasisWSSSecurityUtilUrl = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        
        // Summary:
        //     Represents the Uniform Resource Identifier (URI) for the wss extension namespace
        //     transformation. This field is constant.
        public const string xmlOasisWSSSecurityExtUrl = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        // This function expands the overriden GetIdElement method of the
        // base SignedXML class to search for attribute "id" in addition to
        // the default "Id" attribute.
        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            if (document == null)
                return null;
            // Get the element with idValue
            XmlElement elem = document.GetElementById(idValue);
            if (elem != null)
                return elem;
            // Make a list of the possible id's since it is case sensitive.
            string[] arraySearchIDs = { "id", "Id", "ID", "wsu:id", "wsu:Id", "wsu:ID", "WSU:id", "WSU:Id", "WSU:ID" };
            // search with namespace wsu
            // http://stackoverflow.com/questions/5099156/malformed-reference-element-when-adding-a-reference-based-on-an-id-attribute-w
            XmlNamespaceManager nsManager = new XmlNamespaceManager(document.NameTable);
            nsManager.AddNamespace("wsu", CustomSignedXml.xmlOasisWSSSecurityUtilUrl);
            foreach (string idLabel in arraySearchIDs)
            {
                // Get the element with idValue, try all combinations in array
                string xpathId = "//*[@" + idLabel + "=\"" + idValue + "\"]";
                elem = document.SelectSingleNode(xpathId, nsManager) as XmlElement;
                if (elem != null)
                    return elem;
            }
            return elem;
        }
    }
    }
