    using FluentValidation;
    using System.Collections.Generic;
    
    namespace Test.Validator
    {
    
        public class EmailCollection
        {
            public IEnumerable<string> email { get; set; }
    
        }
    
        public class EmailValidator:  AbstractValidator<string>
        {
            public EmailValidator()
            {
                RuleFor(x => x).Length(0, 5);
            }
    
        }
    
        public class EmailListValidator: AbstractValidator<EmailCollection>
        {
            public EmailListValidator()
            {
                RuleFor(x => x.email).SetCollectionValidator(new EmailValidator());
            }
    
        }
    
    
    
    }
