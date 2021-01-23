    public SomeClass
    {
        private const string UrlValidatorRegex = "http://...
        private const DateTime MinValidSomeDate = ...
        private const DateTime MaxValidSomeDate = ...
        public string SomeUrl { get; set; }
        public DateTime SomeDate { get; set; }
        ...
        private ValidationResult ValidateProperties()
        {
            var urlValidator = new RegEx(urlValidatorRegex);
            if (!urlValidator.IsMatch(this.Someurl))
            {
                return new ValidationResult
                    {
                        IsValid = false,
                        Message = "SomeUrl format invalid."
                    };
            }
            if (this.SomeDate < MinValidSomeDate 
                || this.SomeDate > MinValidSomeDate)
            {
                return new ValidationResult
                    {
                        IsValid = false,
                        Message = "SomeDate outside permitted bounds."
                    };
            }
            ...
            // Check other fields and properties here, return false on failure.
            ...
            return new ValidationResult
                    {
                        IsValid = true,
                    };
        }
        ...
        private struct ValidationResult
        {
            public bool IsValid;
            public string Message;
        }
    }
