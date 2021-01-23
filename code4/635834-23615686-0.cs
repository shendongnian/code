    {
       GlobalConfiguration.Configuration.Services.Add(typeof(System.Web.Http.Validation.ModelValidatorProvider),
           new WebApiFluentValidationModelValidatorProvider()
           {
               AddImplicitRequiredValidator = false //we need this otherwise it invalidates all not passed fields(through json). btw do it if you need
           });
           FluentValidation.ValidatorOptions.ResourceProviderType = typeof(FluentValidationMessages); // if you have any related resource file (resx)
           FluentValidation.ValidatorOptions.CascadeMode = FluentValidation.CascadeMode.Continue; //if you need!
