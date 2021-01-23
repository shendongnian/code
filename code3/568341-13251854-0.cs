		public class LenghtAttribute : Attribute
		{
			public int MaxLength { public get; private set; }
			public LenghtAttribute(int lenght)
			{
				this.MaxLength = lenght;
			}
		}
		public class SomeClass
		{
			private string _someString;
			[Lenght(200)]
			public string SomeString
			{
				get { return _someString; }
				set
				{
					Utils.ValidateLength("SomeString", this, value);
					_someString = value;
				}
			}
		}
		public static class Utils
		{
			public static void ValidateLength(string property, object instance, string value)
			{
				var maxLength = instance.GetType().GetProperty(property)
					.GetCustomAttributes(false).OfType<LenghtAttribute>().First().MaxLength;
				if (value != null && value.Length > maxLength)
					throw new Exception(string.Format("Max length is {0}!", maxLength));
			}
		}
