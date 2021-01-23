	public static class NumberHelper
	{
		public static decimal ToDecimal(this NSDecimal number)
		{
			var stringRepresentation = new NSDecimalNumber (number).ToString ();
			return decimal.Parse(stringRepresentation, CultureInfo.InvariantCulture);
		}
		public static NSDecimal ToNSDecimal(this decimal number)
		{
			return new NSDecimalNumber(number.ToString(CultureInfo.InvariantCulture)).NSDecimalValue;
		}
	}
