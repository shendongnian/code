    public class StringToImageConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == DependencyProperty.UnsetValue || !(value is string))
            {
                return null; //Handle error your way here
            }
            if ((string)value == "Partly Cloudy")
            {
                return new ImageSourceConverter().ConvertFromString("WeatherIcons/03.png");
            }
            else
            {
               // More Implementations and error handling etc
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        #endregion
    }
