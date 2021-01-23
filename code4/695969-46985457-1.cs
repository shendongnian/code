    class UtcToLocalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;
                return dateTime.ToLocalTime();
            }
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;
                return dateTime.ToUniversalTime();
            }
            return Binding.DoNothing;
        }
    }
