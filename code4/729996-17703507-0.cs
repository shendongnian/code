     // Sample Implementation. 
             var validationResult = base.Validate(validationContext).ToList();  
            // validationResult.AddRange(xxx); // an example of mini call for common validations
             if (true) // the condition that leads to a validation error
             {
                 var memberList = new List<string> { "PropertyName" }; // the name of the offending property
                 var error = new ValidationResult("Error text goes here", memberList); // 
                 validationResult.Add(error);
             }
             return validationResult;
           
