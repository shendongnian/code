    public class CodeConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                       System.Globalization.CultureInfo culture)
        {
            try
            {
                string result = value.ToString();
                if (result.Length > 10)
                {
                    // code in your exact requirements here...
                    return result.Substring(0, 10);
                }
                return result;
            }
            catch{}
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter,      
                         System.Globalization.CultureInfo culture)
        {
            return null;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
