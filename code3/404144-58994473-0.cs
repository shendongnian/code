    public X509Certificate2 GeneratePfxCertificate(string certificatePath, string privateKeyPath,
        string certificatePfxPath, string rootCertificatePath, string pkcs12Password)
    {
        string keyFileContent = File.ReadAllText(privateKeyPath);
        string certFileContent = File.ReadAllText(certificatePath);
        string rootCertFileContent = File.ReadAllText(rootCertificatePath);
        var certBio = new BIO(certFileContent);
        var rootCertBio = new BIO(rootCertFileContent);
        CryptoKey cryptoKey = CryptoKey.FromPrivateKey(keyFileContent, string.Empty);
        var certificate = new OpenSSL.X509.X509Certificate(certBio);
        var rootCertificate = new OpenSSL.X509.X509Certificate(rootCertBio);
        using (var certChain = new Stack<OpenSSL.X509.X509Certificate> { rootCertificate })
        using (var p12 = new PKCS12(pkcs12Password, cryptoKey, certificate, certChain))
        using (var pfxBio = BIO.MemoryBuffer())
        {
            p12.Write(pfxBio);
            var pfxFileByteArrayContent =
                pfxBio.ReadBytes((int)pfxBio.BytesPending).Array;
            File.WriteAllBytes(certificatePfxPath, pfxFileByteArrayContent);
        }
        return new X509Certificate2(certificatePfxPath, pkcs12Password);
    }
  [1]: https://github.com/openssl-net/openssl-net
