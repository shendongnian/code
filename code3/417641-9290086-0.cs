    byte[] publicKeyBytes = Convert.FromBase64String(publicKeyString);
    AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(publicKeyBytes);
    RsaKeyParameters rsaKeyParameters = (RsaKeyParameters) asymmetricKeyParameter;
    RsaParameters rsaParameters = new RsaParameters();
    rsaParameters.Modulus = rsaKeyParameters.Modulus;
    rsaParameters.Exponent = rsaKeyParameters.Exponent;
    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
    rsa.ImportParameters(rsaParameters);
