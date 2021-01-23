    X509Certificate2 Certificate = new X509Certificate2( "Certificate.pfx" );
    X509Chain CertificateChain = new X509Chain();
    //If you do not provide revokation information, use the following line.
    CertificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
    bool IsCertificateChainValid = CertificateChain.Build( Certificate );
