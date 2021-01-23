    [ValueConversion(typeof(string), typeof(Object))]
    public class StringToCurrencyEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {   
            if (value!=null)
            {
                CurrenciesEnum enumValue = (CurrenciesEnum)value;
                return enumValue;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string temp = ((CurrenciesEnum) value).ToString();
                return temp;
            }
            return null;
        }
    }
