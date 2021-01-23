    namespace MyProject.Converters
    {
        public class FormatConverter : IValueConverter
        {//Suitable only for read-only data
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null)
                    return string.Empty;
                if(string.IsNullOrEmpty(parameter.ToString()))
                    return value.ToString();
                return string.Format(culture, parameter.ToString(), value);
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
    }
