	public class CustomFormatter :  IFormatProvider, ICustomFormatter
	{
		public object GetFormat(Type formatType)
		{
			if (formatType == typeof(ICustomFormatter))
				return this;
			else if(formatType == typeof(NumberFormatInfo))
			{
				NumberFormatInfo nfi = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone(); // create a copy of the current NumberFormatInfo
				nfi.CurrencySymbol = "Foo"; // change the currency symbol to "Foo" (for instance)
				return nfi; // and return our clone
			}
			else
				return null;
		}
		public string Format(string fmt, object arg, IFormatProvider formatProvider)
		{
			return "test";
		}
	}
