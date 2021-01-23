     using System.Xml;
     using System.Security.Cryptography.X509Certificates;
     using System.Security.Cryptography.Xml;
     using System.Text;
     
     namespace MySamlDocumentExample
     {
         public class Saml20Transaction : SignedXml
         {
             public Saml20Transaction(XmlDocument doc) 
                 : base (doc)
             {
                 
             }
         }
     
         public class SamlVerifier
         {
             readonly XmlDocument _mySamlDocument = new XmlDocument();
     
             public SamlVerifier(string saml)
             {
                 _mySamlDocument.LoadXml(saml);
             }
     
             public X509Certificate2 X509Certificate
             {
                 get
                 {
                     return new X509Certificate2(
                         Encoding.ASCII.GetBytes(X509CertificateString));
                 }
             }
     
             public string X509CertificateString
             {
                 get
                 {
                     XmlNodeList xmlNodeList = _mySamlDocument.GetElementsByTagName("X509Certificate");
                     return xmlNodeList[0].InnerText;
                 }
             }
     
             public bool ValidateSignature()
             {
                 Saml20Transaction saml20Transaction = new Saml20Transaction(_mySamlDocument);
                 XmlNodeList xmlNodeList = _mySamlDocument.GetElementsByTagName("Signature");
                 saml20Transaction.LoadXml((XmlElement)xmlNodeList[0]);
                 return saml20Transaction.CheckSignature(X509Certificate, true);
             }
         }
     }
