    public class DateValueConverter : IValueConverter 
    {
    	public object Convert(object value, System.Type targetType,
                                object parameter, CultureInfo culture)
        {
            DateTime DT = (DateTime)value;
            return DT.ToShortDateString();
        }
        public object ConvertBack(object value, System.Type targetType,
                      object parameter, CultureInfo culture)
        {
            return null;
        }
    }
