      public class MustBeGreaterIfTrueAttribute : ValidationAttribute
      {
        // name of the OtherProperty. You have to specify this when you apply this attribute
        public string OtherPropertyName { get; set; }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
          var otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
    
          if (otherProperty == null)
            return new ValidationResult(String.Format("Unknown property: {0}.", OtherPropertyName));
    
          var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);
    
          if (value.ToString() == "0")
          {
            if (otherPropertyValue != null && otherPropertyValue.ToString() == "true")
            {
              return null;
            }
          }
    
          return new ValidationResult("write something here");
        }
      }
