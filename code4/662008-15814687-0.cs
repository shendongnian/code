	public class FooValidator : AbstractValidator<Foo>
	{
		public FooValidator()
		{
			RuleFor(x => x.Email)
				.Matches(customerSettings.RestrictLoginPattern)
				.WithMessage(localizationService.GetResource("Customer.Fields.Email.EnteredPasswordWrongFormat"))
				//When User is a full email address
				//Make sure its a valid email address
				.When(x => x.Contains('@') || x.EndsWith("@yourdomain.com"));
				
			RuleFor(x => x.Email)
				.Matches(InternalUsernamePattern)
				.WithMessage("foobaz")
				//Username does not contain @
				//Internal user rules!
				.Unless(x => x.Contains('@')|| x.EndsWith("@yourdomain.com"));
		}
	
	}
