    public class ValidateObjectAttribute : ValidationAttribute
    {
        private ValidationContext ValidationContext { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.ValidationContext = validationContext;
            var results = new List<ValidationResult>();
            try
            {
                var isIterable = this.IsIterable(value);
                if (isIterable)
                {
                    int currentItemPosition = -1;
                    foreach (var objectToValidate in value as IEnumerable<object>)
                    {
                        currentItemPosition++;
                        results.AddRange(ValidationsForObject(objectToValidate, true, currentItemPosition));
                    }
                }
                else
                    results = ValidationsForObject(value);
                //Build a validation result 
                List<string> memberNames = new List<string>();
                results.ForEach(r => memberNames.AddRange(r.MemberNames));
                var compositeResultsReturn = new CompositeValidationResult($"Validation for {validationContext.DisplayName} failed!", memberNames.AsEnumerable());
                results.ForEach(r => compositeResultsReturn.AddResult(r));
                return compositeResultsReturn;
            }
            catch (Exception) { }
            return ValidationResult.Success;
        }
        private List<ValidationResult> ValidationsForObject (object objectToValidate, bool IsIterable = false, int position = -1)
        {
            var results = new List<ValidationResult>();
            var contextTemp = new ValidationContext(objectToValidate, null, null);
            var resultsForThisItem = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(objectToValidate, contextTemp, resultsForThisItem, true);
            foreach (var validationResult in resultsForThisItem)
            {
                List<string> propNames = new List<string>();// add prefix to properties
                foreach (var nameOfProp in validationResult.MemberNames)
                {
                    if (IsIterable)
                        propNames.Add($"{this.ValidationContext.MemberName}[{position}].{nameOfProp}");
                    else
                        propNames.Add($"{this.ValidationContext.MemberName}.{nameOfProp}");
                }
                var customFormatValidation = new ValidationResult(validationResult.ErrorMessage, propNames);
                results.Add(customFormatValidation);
            }
            return results;
        }
        private bool IsIterable(object value)
        {
            ////COULD WRITE THIS, but its complicated to debug...
            //if (value.GetType().GetInterfaces().Any(
            //i => i.IsGenericType &&
            //i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            //{
            //    // foreach...
            //}
            Type valueType = value.GetType();
            var interfaces = valueType.GetInterfaces();
            bool isIterable = false;
            foreach (var i in interfaces)
            {
                var isGeneric = i.IsGenericType;
                bool isEnumerable = i.GetGenericTypeDefinition() == typeof(IEnumerable<>);
                isIterable = isGeneric && isEnumerable;
                if (isIterable)
                    break;
            }
            return isIterable;
        }
    }
    public class CompositeValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();
        public IEnumerable<ValidationResult> Results
        {
            get
            {
                return _results;
            }
        }
        public CompositeValidationResult(string errorMessage) : base(errorMessage)
        {
        }
        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames)
        {
        }
        protected CompositeValidationResult(ValidationResult validationResult) : base(validationResult)
        {
        }
        public void AddResult(ValidationResult validationResult)
        {
            _results.Add(validationResult);
        }
    }
