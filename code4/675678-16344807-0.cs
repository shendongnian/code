    private string InitAuth(X509Certificate certificate, string systemId, string username, string password)
        { 
            byte[] plainBytes = Encoding.UTF8.GetBytes(password);
            var cipherB64 = string.Empty;
            //Create a new instance of RSACryptoServiceProvider.
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            //Create a new instance of RSAParameters.
            RSAParameters RSAKeyInfo = new RSAParameters();
            //Set RSAKeyInfo to the public key values. 
            RSAKeyInfo.Modulus = certificate.getPublicKey();
            RSAKeyInfo.Exponent = new byte[3] {1,0,1};;
            //Import key parameters into RSA.
            RSA.ImportParameters(RSAKeyInfo);
            using (RSA)
                cipherB64 = systemId + "^" + username + "^" + Convert.ToBase64String(RSA.Encrypt(plainBytes, true));
    
            return cipherB64;
        }
