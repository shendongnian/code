    public class RemoveLineFeedCharConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value; //do not convert in that direction
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var text = (string) value;
            return text.Replace("\r", ""); //remove line feed character
        }
    }
