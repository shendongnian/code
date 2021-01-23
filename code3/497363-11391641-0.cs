	public class CustomValidationRule : ValidationRule
	{
		private static bool IsValid(string value)
		{
			// implement you business rule checking logic here
			// if valid
			//     return true;
			// else
			//     return fase;
		}
	
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			var val = (string)value;
			if(IsValid(val))
			{
				return ValidationResult.ValidResult;
			}
			else
			{
				return new ValidationResult(false, "Value is not valid");
			}
		}
	}
