    public static class CommonValidators
	{
		public static bool CheckValidEmails(string emails)
		{
			if(string.IsNullOrWhiteSpace(emails))
			{
				return true;
			}
			var list = emails.Split(';');
			var isValid = true;
			foreach (var t in list)
			{
				var email = new EmailModel { Email = t.Trim() };
				var validator = new EmailModelValidator();
				isValid = validator.Validate(email).IsValid;
				if (!isValid)
				{
					break;
				}
			}
			return isValid;
		}
		private class EmailModel
		{
			public string Email { get; set; }
		}
		private class EmailModelValidator : AbstractValidator<EmailModel>
		{
			public EmailModelValidator()
			{
				RuleFor(x => x.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible).When(x => !string.IsNullOrWhiteSpace(x.Email));
			}
		}
	}
