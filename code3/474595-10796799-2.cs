	public class ValueConverter : IValueConverter
	{
		public object Convert(
                    object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((double) value < 0) ? Brushes.Red : Brushes.Black;
		}
		public object ConvertBack(
                    object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
