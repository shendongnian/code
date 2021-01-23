    class AnimationEnablerConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			bool enableAnimation = (bool)value;
			if (enableAnimation)
			{
				return new System.Windows.Duration(new TimeSpan(0, 0, 0, 0, 200));
			}
			else
			{
				return new System.Windows.Duration(new TimeSpan(0, 0, 0, 0, 0));
			}
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
