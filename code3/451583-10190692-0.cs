    public class AccountsValidator : AbstractValidator<AccountViewModel>
    {
        public AccountsValidator()
        {
            RuleFor(x => x.Accounts).SetCollectionValidator(
                new AccountValidator("Accounts")
            );
        }
    }
    public class AccountValidator : AbstractValidator<string> 
    {
        public AccountValidator(string collectionName)
        {
            RuleFor(x => x)
                .NotEmpty()
                .OverridePropertyName(collectionName);
        }
    }
