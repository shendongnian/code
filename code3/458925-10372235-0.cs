    public class MmSsFormatConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int32 sss = (Int32)value;
            Int32 ss = sss / 1000;
            Int32 mm = ss / 60;
            ss = ss % 60;
            return string.Format(@"{0,2}:{1,2}", mm, ss);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
