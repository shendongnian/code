     protected void Validate(string propertyName, string propertyValue, List<ValidRule> validRules) {
          string temp = propertyValue.ToString();
          this.RemoveError(propertyName);
          if(propertyName.Equals("Description")) {
               foreach(ValidRule validRule in validRules) {
                    if(!Regex.IsMatch(propertyValue, validRule.Rule) && !String.IsNullOrWhiteSpace(propertyValue)) {
                         this.AddError(propertyName, validRule.ErrorMessage);
                         break;
                    }
               }
          }
     }
