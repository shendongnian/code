        ClientCredentials credentials = new ClientCredentials();
        credentials.UserName.UserName = userName;
        credentials.UserName.UserName = userName;
        credentials.UserName.Password = password;
        IServiceManagement<IOrganizationService> orgServiceManagement = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(new Uri(organizationUrl));
        AuthenticationCredentials authCredentials = new AuthenticationCredentials();
        authCredentials.ClientCredentials = credentials;
        authCredentials.SupportingCredentials = new AuthenticationCredentials();
        authCredentials.SupportingCredentials.ClientCredentials = Microsoft.Crm.Services.Utility.DeviceIdManager.LoadOrRegisterDevice();
        AuthenticationCredentials tokenCredentials = orgServiceManagement.Authenticate(authCredentials);
        var organizationTokenResponse = tokenCredentials.SecurityTokenResponse;
        OrganizationServiceProxy _serviceProxy;
        IOrganizationService _service;
        using (_serviceProxy = new OrganizationServiceProxy(orgServiceManagement, organizationTokenResponse))
        {
            _service = (IOrganizationService)_serviceProxy;
            WhoAmIResponse response = (WhoAmIResponse)_service.Execute(new WhoAmIRequest());
            Console.WriteLine(response.UserId.ToString());
        }
