    public class User
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            this.ValidateName(x => x.Username);
            this.ValidateName(x => x.FirstName);
            this.ValidateName(x => x.LastName);
        }
    }
    public static class ValidationExtensions
    {
        public static void ValidateName<TV>(this AbstractValidator<TV> validator, Expression<Func<TV, string>> property)
        {
            validator.RuleFor(property).Length(4, 9).WithMessage("Valid between 4 and 9 chars");
        }
    }
