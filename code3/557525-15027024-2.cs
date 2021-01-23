    public class FluentValidationModelValidator : ModelValidator
    {
        public IValidator InnerValidator { get; private set; }
        public FluentValidationModelValidator(
            IEnumerable<ModelValidatorProvider> validatorProviders, IValidator validator)
            : base(validatorProviders)
        {
            InnerValidator = validator;
        }
        public override IEnumerable<ModelValidationResult> Validate(ModelMetadata metadata, object container)
        {
            if (InnerValidator != null && container != null)
            {
                var result = InnerValidator.Validate(container);
                return GetResults(result);
            }
            return new List<ModelValidationResult>();
        }
        private static IEnumerable<ModelValidationResult> GetResults(FluentValidation.Results.ValidationResult result)
        {
            var modelResults = new List<ModelValidationResult>();
            if (!result.IsValid)
            {
                modelResults.AddRange(
                    result.Errors.Select(
                        error =>
                        new ModelValidationResult
                        {
                            MemberName = error.PropertyName,
                            Message = error.ErrorMessage
                        }));
            }
            return modelResults;
        }
    }
