    namespace MyProject.Converters
        {
            /// <summary>
            /// A upper case converter for string values.
            /// </summary>
            public class UpperCaseConverter : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    return ConvertToUpper(value);
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    return ConvertToUpper(value);
                }
        
                private string ConvertToUpper(object value)
                {
                    if (value != null)
                    {
                        return value.ToString().ToUpper();
                    }
                    return null;
                }
            }
        }
