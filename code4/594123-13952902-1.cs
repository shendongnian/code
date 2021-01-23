    // NOTE: Your property is BOOL not STRING.
    public class BoolToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if(value is bool)
                if((bool)value) return new GridLength(1, DataGridLengthUnitType.Star);
                else return new GridLength(0);
            throw new ArgumentException("Not a bool");
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            // You may not need this method at all!
            if(value is GridLength)
                return ((GridLength)value).Value == 0);
            throw new ArgumentException("Not a GridLength");
        }
    }
