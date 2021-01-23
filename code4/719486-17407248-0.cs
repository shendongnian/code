    [ValueConversion(typeof(string), typeof(string))]
    public class pathtoname : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter ,CultureInfo culture)
        {
            BindingList<string> ls = value as BindingList<string>;
            return ls.Select(x => "WW");
        }
    
        public object ConvertBack(object value, Type targetType, object parameter,CultureInfo culture)
        {
            return null;
        }
    }
