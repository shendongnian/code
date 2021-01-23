    public class AccountValidator : AbstractValidator<Account>
    {
        private readonly MyContext _context;
    
        public AccountValidator(MyContext context) : base()
        {
            _context = context;
        }
    
        public override ValidationResult Validate(ValidationContext<Account> context)
        {
            var result      = base.Validate(context);
            var resource    = context.InstanceToValidate;
    
            if (_context.Accounts.Any(account => String.Equals(account.EmailAddress, resource.EmailAddress)))
            {
                result.Errors.Add(
                    new ValidationFailure("EmailAddress", String.Format("An account with an email address of '{0}' already exists.", resource.EmailAddress))
                );
            }
    
            return result;
        }
    }
