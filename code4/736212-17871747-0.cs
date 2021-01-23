    public class ForegroundColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string sValue = (string)value;
            SolidColorBrush pBrush = new SolidColorBrush(Colors.White);
            if (sValue.ToLower() == "red") pBrush = new SolidColorBrush(Colors.Red);
            return pBrush;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
