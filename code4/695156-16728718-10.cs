    public class SplitterConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            string combinedString = value as string;
            if (!string.IsNullOrEmpty(combinedString)) {
                string [] splitArray = combinedString.Split('*');
                int postion = int.Parse(parameter as string);
                switch (postion) {
                    case 0:
                        return splitArray[0];
                    case 1:
                        return splitArray[1];
                    case 2:
                        return splitArray[2];
                    default: 
                        return null;
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
