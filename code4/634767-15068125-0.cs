    X509Certificate2 singingCertificate = new X509Certificate2(certificateFile, certificatePassword);
    Saml2SecurityTokenHandler handler = CreateTokenHandler();
    Saml2SecurityToken baseToken = GetTemplateToken();
    Saml2Assertion assertion = templateToken.Assertion;
    //modify template token - change date, add claims etc
    assertion.Id = new Saml2Id();
    //order is important, because in sampleToken this property is already setup and NotBefore date can not be NotOnOrAfter
    assertion.Conditions.NotOnOrAfter = DateTime.MaxValue;
    assertion.Conditions.NotBefore = DateTime.UtcNow;
    //prepare to resign token assertions
    X509AsymmetricSecurityKey signingKey = new X509AsymmetricSecurityKey(singingCertificate);
    X509RawDataKeyIdentifierClause x509clause = new X509RawDataKeyIdentifierClause(singingCertificate);
    SecurityKeyIdentifier keyIdentifier = new SecurityKeyIdentifier(new SecurityKeyIdentifierClause[] { x509clause });
    assertion.SigningCredentials = new SigningCredentials
        (
        signingKey,
        assertion.SigningCredentials.SignatureAlgorithm,
        assertion.SigningCredentials.DigestAlgorithm,
        keyIdentifier
        );
    //create and sign modified token
    Saml2SecurityToken token = new Saml2SecurityToken(assertion, new ReadOnlyCollection<SecurityKey>(new List<SecurityKey>() { signingKey }), templateToken.IssuerToken);
		
