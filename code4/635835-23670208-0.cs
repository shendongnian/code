        /// <summary>
        /// Set up Fluent Validation for WebApi.
        /// </summary>
        private static void FluentValidationSetup(IKernel kernel)
        {
            var ninjectValidatorFactory
                            = new NinjectFluentValidatorFactory(kernel);
            // Configure MVC
            FluentValidation.Mvc.FluentValidationModelValidatorProvider.Configure(
                provider => provider.ValidatorFactory = ninjectValidatorFactory);
            // Configure WebApi
            FluentValidation.WebApi.FluentValidationModelValidatorProvider.Configure(
                provider => provider.ValidatorFactory = ninjectValidatorFactory);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }
