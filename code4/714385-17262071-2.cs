    public class SortStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (int) value;
            var returnVal = string.Empty;
            switch (val)
            {
                case 0:
                    returnVal = "ABC";
                    break;
                case 1:
                    returnVal = "ZYX";
                    break;
                case 2:
                    returnVal = "Default";
                    break;
            }
            return returnVal;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
