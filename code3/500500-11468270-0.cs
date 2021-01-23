    public class MyConverter : IValueConverter {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                if (value.ToString() == "01.01.0001 0:00:00") {
                    return "No payment";
                }
                return value;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                throw new NotImplementedException();
            }
        }
