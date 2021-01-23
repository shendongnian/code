    public static void Start()
    {
        var factory = new DependencyResolverValidatorFactory();
        var provider = new FluentValidationModelValidatorProvider(factory);
    
        // add remote capabilities
        FluentValidationModelValidationFactory validationFactory = (metadata, context, rule, validator) => new RemoteFluentValidationPropertyValidator(metadata, context, rule, validator);
        provider.Add(typeof(RemoteValidator), validationFactory);
    
        ModelValidatorProviders.Providers.Add(provider);
        DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
    }
