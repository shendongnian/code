    var registry = new ConfigurationBasedIssuerNameRegistry();
    registry.AddTrustedIssuer(Constants.IdSrv.SigningCertThumbprint, Constants.IdSrv.IssuerUri);
    var handlerConfig = new SecurityTokenHandlerConfiguration();
    handlerConfig.AudienceRestriction.AllowedAudienceUris.Add(new Uri(Constants.Realm));
    handlerConfig.IssuerNameRegistry = registry;
    handlerConfig.CertificateValidator = GetX509CertificateValidatorSetting();
            
    X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadOnly);
    X509Certificate2Collection certificates = store.Certificates;
    X509Certificate2Collection matchingCertificates = certificates.Find(
        X509FindType.FindBySubjectDistinguishedName,
        "CN=RPTokenCertificate", false);
    X509Certificate2 certificate = certificates[0];
    List<SecurityToken> serviceTokens = new List<SecurityToken>();
    serviceTokens.Add(new X509SecurityToken(certificate));
    SecurityTokenResolver serviceResolver =
        SecurityTokenResolver.CreateDefaultSecurityTokenResolver(
            serviceTokens.AsReadOnly(), false);
    handlerConfig.ServiceTokenResolver = serviceResolver;
    authentication.AddSaml2(handlerConfig, 
        AuthenticationOptions.ForAuthorizationHeader(SamlScheme), 
        AuthenticationScheme.SchemeOnly(SamlScheme));
