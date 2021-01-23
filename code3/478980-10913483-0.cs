	public class MyInverseConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var trans = value as ScaleTransform;
			return trans.Inverse;
		}
	}
