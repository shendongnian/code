    public class DateTimeConverter: IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, CultureInfo 
            {
               string dateTimeString = value as string; 
               //Convert to DateTime from dateTimeString 
            }
     
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                DateTime dt = (DateTime)value;
               //convert back to string from dt 
            }
        }
