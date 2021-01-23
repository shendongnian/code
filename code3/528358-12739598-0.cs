                byte[] signature = Convert.FromBase64String(Signature);
                byte[] data = Encoding.UTF8.GetBytes(Data);
                var x509 = new X509Certificate2(Path.Combine(@"C:\test", @"test\test.crt"));
                var rsa = x509.PublicKey.Key as RSACryptoServiceProvider;
                if (rsa == null)
                {
                    LogMessage("Authorize", "Invalid", Level.Alert);
                    return false;
                }
                string sha1Oid = CryptoConfig.MapNameToOID("SHA1");
               
                //use the certificate to verify data against the signature
                bool sha1Valid = rsa.VerifyData(data, sha1Oid, signature);
                return sha1Valid;
