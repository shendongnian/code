    public class MyConverter : IValueConverter {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                if (value == DateTime.MinValue) {
                    return "No payment";
                }
                return value.ToString();
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                throw new NotImplementedException();
            }
        }
