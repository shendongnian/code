    public static class ValidationExtensions
    {
        public static void ValidateEmail<TV>(this AbstractValidator<TV> validator, Expression<Func<TV, string>> property)
        {
            validator.RuleFor(property).NotEmpty().WithMessage(EmailEmptyMsg);
            // other rules go here...
        }
    }
