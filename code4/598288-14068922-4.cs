    public class NumToBoolConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, 
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value!=null && value is int )
            {
                var val = (int)value;
                return (val==0) ? false : true;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, 
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value!=null && value is bool )
            {
                var val = (bool)value;
                return val ? 1 : 0;
            }
            return null;
        }
        #endregion
    }
