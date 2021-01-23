        public class EmailValidator : AbstractValidator<Email>
		{
			public EmailValidator()
			{
				RuleFor(x => x.From).NotEmpty()
					.Must(CommonValidators.CheckValidEmails)
					.WithMessage($"'{nameof(From)}' some of the emails provided are not a valid email address.");
			}
		}
