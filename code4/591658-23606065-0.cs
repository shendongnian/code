    public class MyEntityValidator : AbstractValidator<MyEntity>
	{
		public MyEntityValidator()
		{
			RuleSet("Create", () =>
				{
					RuleFor(x => x.Email).EmailAddress();
					ExecuteCommonRules();
				});
			ExecuteCommonRules();
		}
		/// <summary>
		/// Rules that should be applied at all times
		/// </summary>
		private void ExecuteCommonRules()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.City).NotEmpty();
		}
	}
