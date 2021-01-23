    //generate a privatekey and public key
    RsaKeyPairGenerator rkpg1 = new RsaKeyPairGenerator();
    rkpg1.Init(new KeyGenerationParameters(new SecureRandom(), Keystrength));
    AsymmetricCipherKeyPair ackp1 = rkpg1.GenerateKeyPair();
    RsaPrivateCrtKeyParameters privateKey = (RsaPrivateCrtKeyParameters)ackp1.Private;
    RsaKeyParameters publicKey = (RsaKeyParameters)ackp1.Public;
    X509Name comonname = new X509Name (cname);
    Pkcs10CertificationRequest csr = new Pkcs10CertificationRequest ("SHA1WITHRSA", comonname, publicKey, null, privateKey);
    csr.Verify ();
    StringBuilder sb = new StringBuilder();
    PemWriter pw = new PemWriter (new StringWriter (sb));
    pw.WriteObject (csr);
    pw.Writer.Flush ();
    var pemstring = sb.ToString ();
