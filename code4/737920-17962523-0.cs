     private X509Certificate2 GeneratePFXFile(string certificate,string company,string   email,string state,string locality,string username,string country)
        {
            X509Certificate2 cert = null;
            try
            {
                var kpgen = new RsaKeyPairGenerator();
                kpgen.Init(new KeyGenerationParameters(new SecureRandom(new CryptoApiRandomGenerator()), 2048));
                var kp = kpgen.GenerateKeyPair();
                var gen = new X509V3CertificateGenerator();
               
                var certName = new X509Name("CN=" + certificate);
                var issuer = new X509Name("C="+country+",O="+company+",OU=LBC Mundial Corp.USA,E="+email+",L="+locality+",ST="+state);
                var serialNo = BigInteger.ProbablePrime(120, new Random());
                gen.SetSerialNumber(serialNo);
                gen.SetSubjectDN(certName);
                gen.SetIssuerDN(issuer);
                gen.SetNotAfter(DateTime.Now.AddYears(50));
                gen.SetNotBefore(DateTime.Now);
                gen.SetSignatureAlgorithm("MD5WithRSA");
                gen.SetPublicKey(kp.Public);
              
                gen.AddExtension(
                    X509Extensions.AuthorityKeyIdentifier.Id,
                    false,
                    new AuthorityKeyIdentifier(
                        SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(kp.Public),
                        new GeneralNames(new GeneralName(certName)),
                        serialNo));
                gen.AddExtension(
                    X509Extensions.ExtendedKeyUsage.Id,
                    false,
                    new ExtendedKeyUsage(new ArrayList() { new DerObjectIdentifier("1.3.6.1.5.5.7.3.1") }));
                var newCert = gen.Generate(kp.Private);
                byte[] pfx = DotNetUtilities.ToX509Certificate(newCert).Export(System.Security.Cryptography.X509Certificates.X509ContentType.Pfx, (string)null);
                X509Store store = new X509Store((StoreName)StoreName.TrustedPeople, (StoreLocation)StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                cert = new X509Certificate2(pfx,(string)null, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
                store.Add(cert);
                store.Close();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return null;
            }
            return cert;
        }
