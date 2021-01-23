    public class BankPageModel : System.ComponentModel.DataAnnotations.IValidatableObject
    {
        public bool AccountRequired { get; set; }
        public Account NewAccount { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // only perform validation here if account required is checked
            if (this.AccountRequired)
            {
                // check your regex here for account
                if (!RegEx.IsMatch(this.NewAccount.AccountCode, "EXPRESSION"))
                {
                    yield return new ValidationResult("Error");
                }
            }
        }
    }     
