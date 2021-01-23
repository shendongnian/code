    public class FileSizeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // don't validate if value is null
                return null;
            }
            // TODO: do whatever validation you were supposed to do
            ...
        }
    }
