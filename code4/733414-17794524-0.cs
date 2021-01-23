    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var model = validationContext.ObjectInstance;
            
        var displayName = validationContext.DisplayName;
        var propertyName = validationContext.ObjectInstance.GetType().GetProperties()
            .Where(p => p.GetCustomAttributes(false).OfType<DisplayAttribute>().Any(a => a.Name == displayName))
            .Select(p => p.Name).SingleOrDefault();
        if (propertyName == null)
            propertyName = displayName;
    
        var property = model.GetType().GetProperty(propertyName);
        var uppercaseAttribute = property.GetCustomAttributes(typeof(UppercaseAttribute), false).SingleOrDefault() as UppercaseAttribute;
    
        if (uppercaseAttribute != null)
        {
            // some code...
        }
    
        // return validation result...
    }
