    public class IsReadImageConverter : IValueConverter  
    {
        public Image ReadImage { get; set; }
        public Image UnreadImage { get; set; }
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool))
            {
                return null;
            }
            bool b = (bool)value;
            if (b)
            {
                return this.ReadImage
            }
            else
            {
                return this.UnreadImage
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
