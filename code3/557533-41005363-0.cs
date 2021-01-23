    public static class WebApiConfig
    {
       public static void Register(HttpConfiguration config)
       {
           // snip...
           //Fluent Validation
           config.Filters.Add(new ValidateModelStateFilter());
           FluentValidationModelValidatorProvider.Configure(config);
       }
    }
