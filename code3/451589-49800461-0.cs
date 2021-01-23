    public class AccountsValidator : AbstractValidator<AccountViewModel>
    {
       public AccountsValidator()
       {
           RuleForEach(x => x.Accounts).NotNull()
       }
    }
