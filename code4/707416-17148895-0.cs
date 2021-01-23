    public class X509ProtectedConfigProvider : ProtectedConfigurationProvider
    {
        #region Fields
    
        private X509Certificate2 cert;
    
        #endregion
    
        // Performs provider initialization. 
        #region Public Methods and Operators
    
        public override XmlNode Decrypt(XmlNode encryptedNode)
        {
            // Load config section to encrypt into xmlDocument instance
            XmlDocument doc = encryptedNode.OwnerDocument;
            EncryptedXml eXml = new EncryptedXml(doc);
            
            eXml.DecryptDocument();
            return doc.DocumentElement;
        }
    
        public override XmlNode Encrypt(XmlNode node)
        {
            // Load config section to encrypt into xmlDocument instance
            XmlDocument doc = new XmlDocument { PreserveWhitespace = true };
            doc.LoadXml(node.OuterXml);
    
            // Encrypt it
            EncryptedXml eXml = new EncryptedXml();
            EncryptedData eData = eXml.Encrypt(doc.DocumentElement, this.cert);
            return eData.GetXml();
        }
    
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
    
            string certSubjectDistName = config["CertSubjectDistinguishedName"];
            string certStoreName = config["CertStoreName"];
    
            X509Store certStore = !string.IsNullOrEmpty(certStoreName) ? new X509Store(certStoreName, StoreLocation.LocalMachine) : new X509Store(StoreLocation.LocalMachine);
    
            try
            {
                certStore.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs = certStore.Certificates.Find(
                    X509FindType.FindBySubjectName, certSubjectDistName, true);
    
                this.cert = certs.Count > 0 ? certs[0] : null;
            }
            finally
            {
                certStore.Close();
            }
        }
    
        #endregion
    }
