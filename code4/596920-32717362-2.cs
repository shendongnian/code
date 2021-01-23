    var behaviorSection = ConfigurationManager.GetSection("system.serviceModel/behaviors") as BehaviorsSection;
    if (behaviorSection != null)
    {
                    // for each behavior, check for client and server certificates
        foreach (EndpointBehaviorElement behavior in behaviorSection.EndpointBehaviors)
        {
            foreach (PropertyInformation pi in behavior.ElementInformation.Properties)
            {
                if (pi.Type == typeof(ClientCredentialsElement))
                {
                    var clientCredentials = pi.Value as ClientCredentialsElement;
                    var clientCert = clientCredentials.ClientCertificate;
                                // TODO: Add code...
                }
            }
        }
    }
