    public class RadioButtonToIntConverter:IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var para = System.Convert.ToInt32(parameter);
            var myChoice = System.Convert.ToInt32(value);
            return para == myChoice;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var para = System.Convert.ToInt32(parameter);
            var isChecked = System.Convert.ToBoolean(value);
            return isChecked ? para : Binding.DoNothing;
        }
    }
