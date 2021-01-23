	public class MultiValueConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var key   = (string)values[0];
			var value = (string)values[1];
			// replace with appropriate logic
			var result = key + ": " + value;
			return result;
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
