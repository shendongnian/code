    protected void Application_Start()
    {
        
       var existingProvider = ModelValidatorProviders.Providers.Single(x => x is ClientDataTypeModelValidatorProvider);
       ModelValidatorProviders.Providers.Remove(existingProvider);
       ModelValidatorProviders.Providers.Add(new myClientDataTypeModelValidatorProvider()); //!!
       myClientDataTypeModelValidatorProvider.ResourceClassKey = typeof(GlobalRes).Name;
       DefaultModelBinder.ResourceClassKey = typeof(GlobalRes).Name;
    }
