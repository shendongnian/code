    void Application_Start(object sender, EventArgs e)
    {
    	FederatedAuthentication.FederationConfigurationCreated += FCC;
    }
    
    private void FCC(object sender, FederationConfigurationCreatedEventArgs e)
    {
    	e.FederationConfiguration.WsFederationConfiguration.PassiveRedirectEnabled = true;
    	e.FederationConfiguration.WsFederationConfiguration.Issuer = "https://mynamespace.accesscontrol.windows.net/v2/wsfederation";
    	e.FederationConfiguration.WsFederationConfiguration.Realm = "http://localhost:81/";
    	e.FederationConfiguration.WsFederationConfiguration.RequireHttps = false;
    }
