    public class NullToBoolConverter : IValueConverter
    {
        public NullToBoolConverter()
        {
            IsNullValue = true;
            IsNotNullValue = false;
        }
        public bool IsNullValue { get; set; }
        public bool IsNotNullValue { get; set; }
        #region Implementation of IValueConverter
        public object Convert(object value, 
            Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? IsNullValue : IsNotNullValue;
        }
        public object ConvertBack(object value, 
            Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
        #endregion
    }
