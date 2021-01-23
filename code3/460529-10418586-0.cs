    public class DataValidator
    {
        public ValidationResult ValidateProjectNumber(string projectNumber)
        {
            //ProjectNumber validation rules...
            if (string.IsNullOrWhiteSpace(projectNumber))
                return new ValidationResult("Project number is requried.");
    
            int projectId;//say your project number is int.
            if (int.TryParse(projectNumber, out projectId))
                return new ValidationResult(string.Format("Project Number '{0}' is not a valid number."));
    
            // more checks....
    
            return ValidationResult.Success;
        }
    
        public ValidationResult ValidateProjectShare(string projectShare)
        {
            //projectShare validation rules...
    
            return ValidationResult.Success;
        }
    }
