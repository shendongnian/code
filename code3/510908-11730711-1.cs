    public sealed class PlaceHolderAttribute:ValidationAttribute
	{
		private readonly string _placeholderValue;
		public override bool IsValid(object value)
		{
			var stringValue = value.ToString();
			if (stringValue == _placeholderValue)
			{
				ErrorMessage = string.Format("Please fill out {0}", _placeholderValue);
				return false;
			}
			return true;
		}
		public PlaceHolderAttribute(string placeholderValue)
		{
			_placeholderValue = placeholderValue;
		}
	}
