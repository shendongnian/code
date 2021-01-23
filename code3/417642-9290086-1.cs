    byte[] publicKeyBytes = Convert.FromBase64String(publicKeyString);
    AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(publicKeyBytes);
    RsaKeyParameters rsaKeyParameters = (RsaKeyParameters) asymmetricKeyParameter;
    RSAParameters rsaParameters = new RSAParameters();
    rsaParameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
    rsaParameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
    rsa.ImportParameters(rsaParameters);
