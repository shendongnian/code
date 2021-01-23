            /// <summary>
            /// Validate an XmlDocuments signature
            /// </summary>
            /// <param name="xnlDoc"> The saml response with the signature elemenet to validate </param>
            /// <returns> True if signature can be validated with certificate </returns>
            public bool ValidateX509CertificateSignature(XmlDocument xnlDoc)
            {
                XmlNodeList XMLSignatures = xnlDoc.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#");
    
                // Checking If the Response or the Assertion has been signed once and only once.
                if (XMLSignatures.Count != 1) return false;
    
                var signedXmlDoc = new SignedXml(xnlDoc);
                signedXmlDoc.LoadXml((XmlElement)XMLSignatures[0]);
    
                var certFinder = new X509CertificateFinder();
                var foundCert = certFinder.GetSignatureCertificate();
    
                CryptoConfig.AddAlgorithm(typeof(RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
                return signedXmlDoc.CheckSignature(foundCert,false);
            }
