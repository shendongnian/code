    public class EnumToDescriptionConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo language)
		{
			var enumValue = value as Enum;
			return enumValue == null ? DependencyProperty.UnsetValue : enumValue.GetDescriptionFromEnumValue();
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
		{
			return value;
		}
	}
