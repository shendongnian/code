    public class BaseConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // do nothing in this dummy implementation
            return null;
        }
    
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // do nothing in this dummy implementation
            return null;
        }
    }
    public class CrazyConverter : BaseConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return ACrazyConverionOfTheValue(...);
        }
    }
