    public class DelimiterConverter : IValueConverter
	{
		public object Convert(Object value, Type targetType, object parameter, CultureInfo culture)
		{
			string[] values = ((string)value).Split("|");
			int index = int.Parse((string)parameter);
			return values[index];
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return "";
		}
