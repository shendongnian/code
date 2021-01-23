      using Microsoft.Practices.EnterpriseLibrary.Validation;
      using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
    
        namespace MyApp.ObjectModel {
          public class Account {
            private String _accountNumber = String.Empty;
            [StringLengthValidator(1, 50, MessageTemplateResourceName="ValidationStringLength", MessageTemplateResoourceType = typeof(MyApp.Properties.ErrorMessages), Tag="Account Number")]
            public String AccountNumber {
              get { return _accountNumber; }
              set { _accountNumber = value; }
            }
    
    
            protected Validator BuildValidator() {
              return ValidationFactory.CreateValidator<Account>();
            } // method::BuildValidator
    
           
            public String Validate() {
              Validator internalValidator = BuildValidator();
              ValidationResults info = internalValidator.Validate(this);
              String result = String.Empty;
    
              if (!info.IsValid) {
                foreach(ValidationResult vr in info) {
                  result += vr.Message;
                }
              }
              return result;
            } // method::Validate
            
    
            public Boolean Save() {
              if (String.IsNullOrEmpty(Validate()) {
                // perform the save operation.
              } else {
                // do something else, log the message or send it back to the screen or whatever.
              }
            }
          } // class::Account
        }
