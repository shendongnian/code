        class CustomConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return value.ToString();
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                int x = -1;
                Int32.TryParse(value.ToString(), out x);
                return x;
            }
        }
