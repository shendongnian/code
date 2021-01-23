    public class DebitRequestValidator{
      public IEnumerable<ValidationResult> Validate(DebitRequestModel model){
        
        //do some validation
        yield return new ValidationResult {
          MemberName = "cardId",
          ErrorMessage = "Invalid CardId."
        }
      }  
