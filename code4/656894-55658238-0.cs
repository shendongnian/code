        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (validationContext == null)
                return null;
            var valResults = new List<ValidationResult>();
            if (!EmailExists))
                valResults.Add(new ValidationResult($"Email is required.", new[] { "EmailErrorMsg" }));
            return valResults;
        }
