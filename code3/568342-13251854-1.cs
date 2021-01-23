		public interface AttributeValidator
		{
			void CheckOk(object value);
		}
		public class LenghtAttribute : Attribute, AttributeValidator
		{
			public int MaxLength { get; private set; }
			public LenghtAttribute(int lenght)
			{
				this.MaxLength = lenght;
			}
			public void CheckOk(object value)
			{
				var str = value as string;
				if (str != value)
					throw new Exception("Not a string!");
				if (str != null && str.Length > MaxLength)
					throw new Exception("To long!");
			}
		}
		public class DoesNotContain : Attribute, AttributeValidator
		{
			public string Chars { get; private set; }
			public DoesNotContain(string chars)
			{
				this.Chars = chars;
			}
			public void CheckOk(object value)
			{
				var str = value as string;
				if (str != value)
					throw new Exception("Not a string!");
				if (str != null && Chars.Any(c => str.Contains(c)))
					throw new Exception("Contains forbidden character!");
			}
		}
		public class SomeClass
		{
			private string _someString;
			[Lenght(200)]
			[DoesNotContain("$#2")]
			public string SomeString
			{
				get { return _someString; }
				set
				{
					Utils.Validate("SomeString", this, value);
					_someString = value;
				}
			}
		}
		public static class Utils
		{
			public static void Validate(string property, object instance, string value)
			{
				var validators = instance.GetType().GetProperty(property)
					.GetCustomAttributes(false).OfType<AttributeValidator>();
				foreach (var validator in validators)
					validator.CheckOk(value);
			}
		}
