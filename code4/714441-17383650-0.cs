    using FluentValidation;
    
    public class CustomerValidator : AbstractValidator<Customer> {
      public CustomerValidator {
        RuleFor(customer => customer.Surname).NotNull();
      }
    }
