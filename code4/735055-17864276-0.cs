    // HACK: The following is a workaround for a bug in .NET Framework 4.0
    //       Discovery should be possible when setup from the App.config with the
    //       following three lines of code:
    //
    //         discoveryClient = new DiscoveryClient("DiscoveryEndpoint");
    //         Collection<EndpointDiscoveryMetadata> serviceCollection = discoveryClient.Find(new FindCriteria(typeof(IExampleContract))).Endpoints;
    //         discoveryClient.Close();
    //
    //       However, a bug in the Discovery Client implementation results in an
    //       ArgumentNullException when running discovery in this way.
    //
    //       The following code overcomes this limitation by manually parsing the
    //       standard WCF configuration sections of App.config, and then configuring
    //       the appropriate FindCriteria for a programmatically configured discovery
    //       cycle.  This code can be replaced by the above three lines when either
    //         1. The bug in .NET Framework 4.0 is resolved (unlikely), or
    //         2. The application is retargeted to .NET Framework 4.5 / 4.5.1
    //
    //       To aid future developers, this HACK will be extensively documented
    
    // Load the App.config file into a ConfigurationManager instance and load the configuration
    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
    // Get the ServiceModel configuration group
    ServiceModelSectionGroup serviceModelGroup = ServiceModelSectionGroup.GetSectionGroup(configuration);
    // Get the StandardEndpoints configuration node
    StandardEndpointsSection section = serviceModelGroup.StandardEndpoints;
    
    // Get the DynamicEndpoint configuration node
    Configuration dynamicEndpointConfiguration = section["dynamicEndpoint"].CurrentConfiguration;
    
    // Get the first DynamicEndpoint configuration
    // HACK: This assumes only one DynamicEndpoint configuration exists
    //       No additional configurations will be interpreted.  This should
    //       not pose a problem as typically a client will only access a
    //       single service instance.  This can be extended if necessary
    //       at a later time.
    DynamicEndpointElement element = ((DynamicEndpointElement)serviceModelGroup.StandardEndpoints["dynamicEndpoint"].ConfiguredEndpoints[0]);
    
    // Set the required Contract Type
    // HACK: This is currently hard-coded to prevent the need to specify
    //       an AssemblyQualifiedName in the App.config file.  This will
    //       not typically pose a problem as each client will typically
    //       only open a single service exposing a single, well-known,
    //       Contract Type
    FindCriteria criteria = new FindCriteria(typeof(IExampleContract));
    
    // Add all required Scopes to the FindCriteria instance
    foreach (ScopeElement scopeElement in element.DiscoveryClientSettings.FindCriteria.Scopes)
    {
        criteria.Scopes.Add(scopeElement.Scope);
    }
    
    // Get the Discovery Duration
    criteria.Duration = element.DiscoveryClientSettings.FindCriteria.Duration;
    
    // Create a new Discovery Client instance
    DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
    
    // Retrieve the matching Service Endpoints via Dynamic Search
    Collection<EndpointDiscoveryMetadata> serviceCollection = discoveryClient.Find(criteria).Endpoints;
    
    // Close the Discovery Client
    discoveryClient.Close();
    
    // HACK: END -- Process the results of Discovery
