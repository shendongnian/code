    public class UnreadMessageBrushconverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // hard-coded colours example,  you may want to look at 
            // using predefined resources for this, though.
            return (bool)value ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.White);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
