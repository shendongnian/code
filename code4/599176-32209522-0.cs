	public class StringEnumerationLengthValidationAttribute : StringLengthAttribute
	{
		public StringEnumerationLengthValidationAttribute(int maximumLength)
			: base(maximumLength)
		{ }
		public override bool RequiresValidationContext { get { return true; } }
		public override bool IsValid(object value)
		{ return false; }
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var e1 = value as IEnumerable<string>;
			if (e1 != null) return IsEnumerationValid(e1, validationContext);
			return ValidationResult.Success; // what if applied to something else than IEnumerable<string> or it is null?
		}
		protected ValidationResult IsEnumerationValid(IEnumerable<string> coll, ValidationContext validationContext)
		{
			foreach (var item in coll)
			{
				// utilize the actual StringLengthAttribute to validate the items
				if (!base.IsValid(item) || (MinimumLength > 0 && item == null))
				{
					return new ValidationResult(base.FormatErrorMessage(validationContext.DisplayName));
				}
			}
			return ValidationResult.Success;
		}
	}
