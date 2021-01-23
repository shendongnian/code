    using System.Web.Mvc;
    ...
    protected void Application_Start()
    {
      var providers = ModelValidatorProviders.Providers;
      var clientDataTypeModelValidatorProvider = providers.OfType<ClientDataTypeModelValidatorProvider>().FirstOrDefault();
      if ( clientDataTypeModelValidatorProvider != null )
      {
        providers.Remove( clientDataTypeModelValidatorProvider );
      }
      ...
    }
