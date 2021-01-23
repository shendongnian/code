        using (CryptContext ctx = new CryptContext())
        {
            ctx.Open();
    
            X509Certificate2 cert = ctx.CreateSelfSignedCertificate(
                new SelfSignedCertProperties
                {
                    IsPrivateKeyExportable = true,
                    KeyBitLength = 4096,
                    Name = new X500DistinguishedName("cn=localhost"),
                    ValidFrom = DateTime.Today.AddDays(-1),
                    ValidTo = DateTime.Today.AddYears(1),
                });
    
            X509Certificate2UI.DisplayCertificate(cert);
        }
