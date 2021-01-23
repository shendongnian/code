    public class StringToImageConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //... Implementation here, make sure value is of type string
            if ((string)value == "Partly Cloudy")
            {
                return new ImageSourceConverter().ConvertFromString("WeatherIcons/03.png");
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
        #endregion
    }
