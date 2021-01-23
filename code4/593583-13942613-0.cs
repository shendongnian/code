    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.BillingEmailAddress)
                .NotEmpty()
                .WithMessage("You must specify Email Address.")
                .Length(1, 255)
                .WithMessage("Email address is too long.")
                .EmailAddress();
        }
    }
