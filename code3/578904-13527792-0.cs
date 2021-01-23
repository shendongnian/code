    public class ApprovalInformation : IValidatableObject
    {
        ... // Properties
    
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if (validationContext.ContainsKey("submit"))
           {
              if (ApproveStatusID != 0)
              {
                  yield return new ValidationResult("You may not set the Approval Decision before saving a service request for later.  Please reset the Approval Decision to blank", 
                                                     new {"ApproveStatusID"});
              }
           }
        }
    }
