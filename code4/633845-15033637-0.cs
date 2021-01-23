    protected override ValidationResult IsValid(object value, ValidationContext context)
            {
                if (value != null) { return ValidationResult.Success; }
    
                Object instance = context.ObjectInstance;
                Type type = instance.GetType();
                Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
                if (proprtyvalue == null) {
                   return new ValidationResult(ErrorMessage);
                }
                return ValidationResult.Success;
            }
