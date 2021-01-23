    public sealed class NotEqualedFirstNameOrLastNameAttribute:ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var stringValue = value.ToString();
			if (stringValue == "FirstName")
			{
				ErrorMessage = "Please fill out first name";
				return false;
			}
			if (stringValue == "LastName")
			{
				ErrorMessage = "Please fill out last name";
				return false;
			}
			return true;
		}
	}
