	public class MyPropertySelectionConverter : IValueConverter
	{
		public static MyPropertySelectionConverter Instance
		{
			get { return s_Instance; }
		}
		public const String NoneString = "(none)";
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Object retval = value as MyPropertyType;
			if (retval == null)
			{
				retval = NoneString;
			}
			return retval;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Object retval = null;
			if (value is MyPropertyType)
			{
				retval = value;
			}
			else if (String.Equals(NoneString, value as String, StringComparison.OrdinalIgnoreCase))
			{
				retval = null;
			}
			else
			{
				retval = DependencyProperty.UnsetValue;
			}
			return retval;
		}
		private static MyPropertySelectionConverter s_Instance = new MyPropertySelectionConverter();
	}
