    public class CustomerValidator: AbstractValidator<Customer> 
    {
		// constructor...
		
		public override ValidationResult Validate(Customer instance)
		{
            return instance == null 
                ? new ValidationResult(new [] { new ValidationFailure("Customer", "Customer cannot be null") }) 
                : base.Validate(instance);
		}
    }
