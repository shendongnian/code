    public class YourValidationClass : ValidationRule
      {
          public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
          {
              BindingGroup bindingGroup = (BindingGroup)value;
    
              if (bindingGroup.Items.Count == 1)
              {
                  User user = (User)bindingGroup.Items[0];
                  string firstName = (string)bindingGroup.GetValue(user, "FirstName");
                  string lastName = (string)bindingGroup.GetValue(user, "LastName");
    
                  if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                  {
                      return new ValidationResult(false, "Both fields required");
                  }
              }
              return ValidationResult.ValidResult;
          }
      }
