    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            this.ValidateEmail(x => x.PrimaryEmail);
            this.ValidateEmail(x => x.SecondaryEmail);
        }
    }
