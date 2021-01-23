            // Jul 10, 2012 see
            // http://social.technet.microsoft.com/Forums/en-NZ/winserversecurity/thread/45781b46-3eb7-4715-b877-883bf0dc2ae7
            // instaed of CX509CertificateRequestPkcs10 csr = new CX509CertificateRequestPkcs10(); use:
            IX509CertificateRequestPkcs10 csr = (IX509CertificateRequestPkcs10)Activator.CreateInstance(Type.GetTypeFromProgID("X509Enrollment.CX509CertificateRequestPkcs10"));
            csr.InitializeDecode(csrText, EncodingType.XCN_CRYPT_STRING_BASE64);
            csr.CheckSignature(Pkcs10AllowedSignatureTypes.AllowedKeySignature);
            //get Bouncy CSRInfo Object
            Trace.Write("get Bouncy CSRInfo Object");
            Byte[] csrBytes = Convert.FromBase64String(csrText);
            CertificationRequestInfo csrInfo = CertificateTools.GetCsrInfo(csrBytes);
            SubjectPublicKeyInfo pki = csrInfo.SubjectPublicKeyInfo;
            //pub key for the signed cert
            Trace.Write("pub key for the signed cert");
            AsymmetricKeyParameter publicKey = PublicKeyFactory.CreateKey(pki);
            // Build a Version1 (No Extensions) Certificate
            DateTime startDate = DateTime.Now;
            DateTime expiryDate = startDate.AddYears(100);
            BigInteger serialNumber = new BigInteger(32, new Random());
            Trace.Write("Build a Version1 (No Extensions) Certificate");
            X509V1CertificateGenerator certGen = new X509V1CertificateGenerator();
            string signerCN = ConfigurationManager.AppSettings["signerCN"].ToString();
            X509Name dnName = new X509Name(String.Format("CN={0}", signerCN));
            X509Name cName = new X509Name(csr.Subject.Name);
            certGen.SetSerialNumber(serialNumber);
            certGen.SetIssuerDN(dnName);
            certGen.SetNotBefore(startDate);
            certGen.SetNotAfter(expiryDate);
            certGen.SetSubjectDN(cName);
            certGen.SetSignatureAlgorithm("SHA1withRSA");
            certGen.SetPublicKey(publicKey);
            //get our Private Key to Sign with
            Trace.Write("get our Private Key to Sign with");
            X509Store store = new X509Store(StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            string signerThumbprint = ConfigurationManager.AppSettings["signerThumbprint"].ToString();
            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByThumbprint, signerThumbprint, false);
            X509Certificate2 caCert = fcollection[0];
            Trace.Write("Found:" + caCert.FriendlyName);
            Trace.Write("Has Private " + caCert.HasPrivateKey.ToString());
            Trace.Write("Key Size " + caCert.PrivateKey.KeySize.ToString());
            //Get our Signing Key as a Bouncy object
            Trace.Write("Get our Signing Key as a Bouncy object from key ");
            AsymmetricCipherKeyPair caPair = DotNetUtilities.GetKeyPair(caCert.PrivateKey);
            //gen BouncyCastle object
            Trace.Write("gen BouncyCastle object");
            Org.BouncyCastle.X509.X509Certificate cert = certGen.Generate(caPair.Private);
            //convert to windows type 2 and get Base64 String
            Trace.Write("convert to windows type 2 and get Base64 String");
            X509Certificate2 cert2 = new X509Certificate2(DotNetUtilities.ToX509Certificate(cert));
            byte[] encoded = cert2.GetRawCertData();
            string certOutString = Convert.ToBase64String(encoded);
            //output to the page (hidden)
            Certificate.Value = certOutString;
