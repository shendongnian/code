    public class EntityToForegroundConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, 
                             Type targetType, 
                             object parameter, 
                             CultureInfo culture) 
        {
            var entity = value as IMyEntity;
            // TODO: determine a foreground value based on bound 
            // object proerrty values
        }
        public object ConvertBack(object value, 
                                  Type targetType, 
                                  object parameter, 
                                  CultureInfo culture)
        {
            return null;
        }
    }
