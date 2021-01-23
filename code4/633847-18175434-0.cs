    X509Certificate cert1 = /* your cert */;
    X509Certificate cert2 = /* your other cert */;
    // assuming you are validating pki chain
    // X509Certificate compares the serial number and issuer
    bool matchUsingSerialAndIssuer = cert1.Equals(cert2);
    // otherwise
    bool publicKeyIsIdentical = cert1.GetCertHashString() == cert2.GetCertHashString();
    // or easier to read if using X509Certificate2 (Thumbprint calls GetCertHashString)
    // bool publicKeyIsIdentical = cert1.Thumbprint == cert2.Thumbprint;
