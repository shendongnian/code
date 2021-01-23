    internal class KearningConverter : IValueConverter {
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            string result = value.ToString();
    
            try {
                int length = int.Parse(parameter.ToString());
    
                if (result.Length > length) {
                    result = result.Substring(0, length) + "...";
                }
            } catch {
                result += "...";
            }
            return result;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
