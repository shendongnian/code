	public enum MyEnum
		{
			This,
			That,
			TheOther
		}
		public static class MyEnumeExtensions
		{
			public static bool IsAny(this MyEnum enumValue, params MyEnum[] values)
			{
				return values.Any((e) => e == enumValue);
			}
		}
