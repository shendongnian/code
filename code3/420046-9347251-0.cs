    public class Employee : IValidatableObject
    {
        
        public string EmployeeName;
    
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            char secondNameChar = EmployeeName[1];
            char thirdNameChar = EmployeeName[2];
    
            if (secondNameChar.ToString().ToLower() != "e")
                yield return
                    new ValidationResult("Second char of name should be 'E'",
                                         new[] {"EmployeeName"});
            if (thirdNameChar.ToString().ToLower() != "f")
                yield return
                    new ValidationResult("Third char of name should be 'F'",
                                         new[] {"EmployeeName"});
            
    
        }
    }
