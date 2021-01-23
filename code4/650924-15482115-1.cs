    [ValueConversion(typeof(bool?), typeof(bool))]
    public class Converter : IValueConverter
    {
        #region IValueConverter Members
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool?))
            {
                throw new InvalidOperationException("The target must be a nullable boolean");
            }
            bool? b = (bool?)value;
            return b.HasValue && b.Value;
        } 
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    
        #endregion
    }
