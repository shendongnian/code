        public class MyCustomModelValidatorProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            return new List<ModelValidator>() { new MyCustomModelValidator(metadata, context) };
        }
        public class MyCustomModelValidator : ModelValidator
        {
            public MyCustomModelValidator(ModelMetadata metadata, ControllerContext context)
                : base(metadata, context)
            {   }
            public override IEnumerable<ModelValidationResult> Validate(object container)
            {
                var model = this.Metadata.Model; 
                if (model is string)
                {
                    var value = model as string;
                    if (String.IsNullOrEmpty(value) || value.Length > 256)
                    {
                        var validationResult = new ModelValidationResult();
                        validationResult.Message = (this.Metadata.DisplayName ?? this.Metadata.PropertyName) 
                            + " needs to be no more then 256 characters";
                        return new List<ModelValidationResult>() { validationResult };
                    }
                }
                return new List<ModelValidationResult>();
            }
        }
    }
