	public class ConnectorLocationConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var start = (Coordinates)values[0];
			var end = (Coordinates)values[1];
			return new Thickness(start.X, start.Y, 0, 0);
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
	public class ConnectorAngleConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var start = (Coordinates)values[0];
			var end = (Coordinates)values[1];
			//dy/dx = tan(t) => t = arcTan(dy/dx)
			double t = Math.Atan2(
						Math.Abs(start.Y - end.Y),
						Math.Abs(start.X - end.X)) * 180 / Math.PI;
			if (end.X <= start.X && end.Y >= start.Y) return 180 - t;
			if (end.X >= start.X && end.Y <= start.Y) return -t;
			if (end.X <= start.X && end.Y <= start.Y) return 180 + t;
			return t;
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
	public class ConnectorWidthConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var start = (Coordinates)values[0];
			var end = (Coordinates)values[1];
			//get side for states
			return Math.Abs(start.X - end.X);
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
	public class ConnectorHeightConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var start = (Coordinates)values[0];
			var end = (Coordinates)values[1];
			//get side for states
			return Math.Abs(start.Y - end.Y);
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
