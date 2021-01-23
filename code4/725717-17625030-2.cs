    [TypeConverter(typeof(DisplayNameEnforcingConverter))]
	public class MyObject
	{
		[DisplayName("ZZZZ")]
		public int AProperty
		{
			get;
			set;
		}
		[DisplayName("BBBB")]
		public int BProperty
		{
			get;
			set;
		}
	}
