      // Private key
      RsaPrivateCrtKeyParameters kparam = ConvertToRSAPrivateKey(privateKey); 
            RSAParameters p1 = DotNetUtilities.ToRSAParameters(kparam);
            rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(p1);
     // Public key
     RsaKeyParameters kparam = ConvertToRSAPublicKey(publicKey);
            RSAParameters p1 = DotNetUtilities.ToRSAParameters(kparam);
            rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(p1);
