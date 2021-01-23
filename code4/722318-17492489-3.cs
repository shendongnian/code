    // Example using the FluentValidation library
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Age).LessThan(100);
            RuleFor(p => p.Name).NotEmpty();
        }
    }
