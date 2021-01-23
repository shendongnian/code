    // create the RSA key from an XML string
    RSACryptoServiceProvider key = new RSACryptoServiceProvider();
    key.FromXmlString(keyTextBox.Text);
    // convert to BouncyCastle key object
    var keypair = DotNetUtilities.GetRsaKeyPair(key);
    var gen = new X509V3CertificateGenerator();
    string certName = Path.GetFileNameWithoutExtension(fileName);
    var name = new X509Name("CN=" + certName);
    var serial = BigInteger.ProbablePrime(120, new Random());
    gen.SetSerialNumber(serial);
    gen.SetSubjectDN(name);
    gen.SetIssuerDN(name);
    gen.SetNotAfter(DateTime.Now.AddYears(10));
    gen.SetNotBefore(DateTime.Now);
    gen.SetSignatureAlgorithm("MD5WithRSA");
    gen.SetPublicKey(keypair.Public);
    // generate the certificate
    var newCert = gen.Generate(keypair.Private);
    // convert back to .NET certificate
    var cert = DotNetUtilities.ToX509Certificate(newCert);
    // export as byte array
    byte[] certData = cert.Export(X509ContentType.Pfx);
    File.WriteAllBytes(fileName, certData);
