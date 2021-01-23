    public class CustomerValidator: AbstractValidator<Customer> 
    {
		// constructor...
		
		public override ValidationResult Validate(Customer instance)
		{
			if (instance == null)
			{
				return new ValidationResult(
					new List<ValidationFailure>{
						new ValidationFailure("Customer", "Customer cannot be null")
					}
				);
			}
			
			return base.Validate(instance);
		}
    }
