        public class EmailValidator : AbstractValidator<Email>
		{
			public EmailValidator()
			{
				RuleFor(x => x.To).NotEmpty()
					.Must(CommonValidators.CheckValidEmails)
					.WithMessage($"'{nameof(To)}' some of the emails provided are not a valid email address.");
			}
		}
