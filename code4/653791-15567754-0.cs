    public class EmptyStringConverter : MarkupExtension, IValueConverter
    {  
        public object Convert(object value, Type targetType, 
                              object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value as string) ? parameter : value;
        }
    
        public object ConvertBack(object value, Type targetType, 
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
