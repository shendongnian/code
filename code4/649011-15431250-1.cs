    public class RuleValidator{
      public ValidationResult Validate(object o){
        ValidationResult result = new ValidationResult();
        List<string> validationErrors = new List<string>();
        PropertyInfo[] properties = o.GetType().GetProperties();
        foreach(PropertyInfo prop in properties){
          // validate here
          // if error occur{
            validationErrors.Add(string.Format("ErrorMessage at {0}", prop.Name));
          //}
        }
        
        result.ErrorMessages = validationErrors.ToArray();
      }
    }
