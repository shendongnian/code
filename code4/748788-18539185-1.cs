 		public ClaimsIdentity DecryptToken(string token)
        {
            XmlReader rdr = XmlReader.Create(new StringReader(token));
            SecurityTokenHandlerConfiguration config = new SecurityTokenHandlerConfiguration();
            config.AudienceRestriction.AllowedAudienceUris.Add(new Uri("urn:yourRP"));
            config.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
            config.RevocationMode = X509RevocationMode.NoCheck;
            ConfigurationBasedIssuerNameRegistry inr = new ConfigurationBasedIssuerNameRegistry();
            X509Certificate2 cert = new X509Certificate2(pathToSigningCert);
            inr.AddTrustedIssuer(cert.Thumbprint, "STS Name");
            config.IssuerNameRegistry = inr;
            config.CertificateValidator = System.IdentityModel.Selectors.X509CertificateValidator.None;
            SecurityTokenHandlerCollection handlers = System.IdentityModel.Tokens.SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection(config);
            if (handlers.CanReadToken(rdr))
            {
                var tmpToken = handlers.ReadToken(rdr);
                var claimsIds = handlers.ValidateToken(tmpToken);
                var id = claimsIds.FirstOrDefault();
            }
        }
