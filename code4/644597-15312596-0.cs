    public class StringIsEmptyToBoolConverter : MarkupExtension, IValueConverter
    {
        public StringIsEmptyToBoolConverter()
        {
            this.Result = false;
        }
        public bool Result { get; set; }
        public object Convert(object value, Type targetType, 
                              object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value as string) ? this.Result : !this.Result;
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
