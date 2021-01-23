    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.Xml;
    using System.Text;
    using System.Xml;
    namespace CustomSecurity
    {
    class XmlDsigDocument : XmlDocument
    {
        // Constants
        public const string XmlDsigNamespacePrefix = "ds";
        /// <summary>
        /// Override CreateElement function as it is extensively used by SignedXml
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="localName"></param>
        /// <param name="namespaceURI"></param>
        /// <returns></returns>
        public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
        {
            // CAntonio. If this is a Digital signature security element, add the prefix. 
            if (string.IsNullOrEmpty(prefix))
            {
                // !!! Note: If you comment this line, you'll get a valid signed file! (but without ds prefix)
                // !!! Note: If you uncomment this line, you'll get an invalid signed file! (with ds prefix within 'Signature' object)
                //prefix = GetPrefix(namespaceURI);
                // The only way to get a valid signed file is to prevent 'Prefix' on 'SignedInfo' and descendants.
                List<string> SignedInfoAndDescendants = new List<string>();
                SignedInfoAndDescendants.Add("SignedInfo");
                SignedInfoAndDescendants.Add("CanonicalizationMethod");
                SignedInfoAndDescendants.Add("InclusiveNamespaces");
                SignedInfoAndDescendants.Add("SignatureMethod");
                SignedInfoAndDescendants.Add("Reference");
                SignedInfoAndDescendants.Add("Transforms");
                SignedInfoAndDescendants.Add("Transform");
                SignedInfoAndDescendants.Add("InclusiveNamespaces");
                SignedInfoAndDescendants.Add("DigestMethod");
                SignedInfoAndDescendants.Add("DigestValue");
                if (!SignedInfoAndDescendants.Contains(localName))
                {
                    prefix = GetPrefix(namespaceURI);
                }
            }
            return base.CreateElement(prefix, localName, namespaceURI);
        }
        /// <summary>
        /// Select the standar prefix for the namespaceURI provided
        /// </summary>
        /// <param name="namespaceURI"></param>
        /// <returns></returns>
        public static string GetPrefix(string namespaceURI)
        {
            if (namespaceURI == "http://www.w3.org/2001/10/xml-exc-c14n#")
                return "ec";
            else if (namespaceURI == SignedXml.XmlDsigNamespaceUrl)
                return "ds";
            return string.Empty;
        }
    }
    }
