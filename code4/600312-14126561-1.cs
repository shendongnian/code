    public static class ObjectExtensions
	{
		public static decimal ToDecimal(this object number)
		{
			decimal value;
            if (number == null) return 0;
            if (decimal.TryParse(number.ToString().Replace("$", "").Replace(",", ""), out value))
				return value;
			else
				return 0;
		}
        public static decimal? ToNullableDecimal(this object number)
		{
			decimal value;
            if (number == null) return null;
            if (decimal.TryParse(number.ToString().Replace("$", "").Replace(",", ""), out value))
				return value;
			else
				return null;
		}
	}
