    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("{0}", c => "The name " + c.Name + " is not valid for Id " + c.Id);
        }
    }
