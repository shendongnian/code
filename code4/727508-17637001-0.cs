    namespace Mvc4Test.Models
    {
        public class Part
        {
            [AlternateValidation(Suggetion = "Please Use 123 (This is a Suggestion)")]
            public string PartNumber { get; set; }
        }
    
        public class AlternateValidation : ValidationAttribute
        {
            public string Suggetion { get; set; }
           
    
            protected override ValidationResult IsValid(object value,ValidationContext validationContext)
            {
                if (value != null)
                {
                    if (value.ToString() == "123")
                    {
    
                        return ValidationResult.Success;
                    }
                    else
                    {
    
                        
                        return new ValidationResult(Suggetion);
    
                    }
                }else
                    return new ValidationResult("Value is Null");
    
            }
        }
    }
