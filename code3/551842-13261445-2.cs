    using (CredentialingService.SOAPPortTypeClient client = GetCredentialingClient())
    {
        client.Open();
        etc....
    }
    private static CredentialingService.SOAPPortTypeClient GetCredentialingClient()
    {
        CredentialingService.SOAPPortTypeClient client = new CredentialingService.SOAPPortTypeClient(GetCustomBinding(), new EndpointAddress(new Uri(Settings.AppSettings.B2BUrl), new DnsEndpointIdentity(Settings.AppSettings.B2BDNSEndpoint), new AddressHeaderCollection()));
        client.Endpoint.Contract.ProtectionLevel = System.Net.Security.ProtectionLevel.None;
        SetClientCredentialsSecurity(client.ClientCredentials);
        return client;
    }
