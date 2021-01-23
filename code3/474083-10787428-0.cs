    public void Execute(IServiceProvider serviceProvider){
            
    // Obtain the execution context from the service provider.
    Microsoft.Xrm.Sdk.IPluginExecutionContext context = (Microsoft.Xrm.Sdk.IPluginExecutionContext)
                serviceProvider.GetService(typeof(Microsoft.Xrm.Sdk.IPluginExecutionContext));
    // Obtain the organization service reference.
    IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory   serviceProvider.GetService(typeof(IOrganizationServiceFactory));
    IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
   }
