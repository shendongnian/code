    public class OperatorPicker : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var pu = value as ProfileUser;
            if (pu != null)
                return OperatorManager.GetByGuId(pu.User_ID);
            return null;
        }
        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
