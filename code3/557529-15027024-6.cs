    public class FluentValidationModelValidator : ModelValidator
    {
        public IValidator innerValidator { get; private set; }
        public FluentValidationModelValidator(
            IEnumerable<ModelValidatorProvider> validatorProviders, IValidator validator)
            : base(validatorProviders)
        {
            innerValidator = validator;
        }
        public override IEnumerable<ModelValidationResult> Validate(ModelMetadata metadata, object container)
        {
            if (InnerValidator != null && container != null)
            {
                var result = innerValidator.Validate(container);
                return GetResults(result);
            }
            return new List<ModelValidationResult>();
        }
        private static IEnumerable<ModelValidationResult> GetResults(FluentValidation.Results.ValidationResult result)
        {
            return result.Errors.Select(error =>
                new ModelValidationResult
                {
                    MemberName = error.PropertyName,
                    Message = error.ErrorMessage
                }));
        }
    }
