        public byte[] sign(string text)
             {
    //Password for the PFX certificate
                string password = "1234";
    //Importing the PFX certificate that contains the private key which will be used for creating the digital signature
                X509Certificate2 cert = new X509Certificate2("c:\\certificate.pfx", password);
    //declaring RSA cryptographic service provider
                RSACryptoServiceProvider crypt = (RSACryptoServiceProvider)cert.PrivateKey;
    //cryptographic hash of type SHA1
                SHA1Managed sha1 = new SHA1Managed();
    //encoding the data to be signed
                UnicodeEncoding encoding = new UnicodeEncoding();
                byte[] data = encoding.GetBytes(text);
    //generate Hash
                byte[] hash = sha1.ComputeHash(data);
    //sign Hash
                return crypt.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
            }
