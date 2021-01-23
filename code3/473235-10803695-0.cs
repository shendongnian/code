        public class UniquenessAttribute : ValidationAttribute
        {
            public UniquenessAttribute()
            {
                ErrorMessageResourceName = "EmailUniqueError";
                ErrorMessageResourceType = typeof (Resources.OurThing);
            }
    
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (failure) // to implement
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                ...
            }
        }
