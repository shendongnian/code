    MyImage.DataContext = "pack://application:,,,/Bilder/sas.png";
 
    public class MyImageSourceConverter : IValueConverter
    {
        public object Convert(object value_, Type targetType_, 
        object parameter_, System.Globalization.CultureInfo culture_)
        {
            return (new ImageSourceConverter()).ConvertFromString (value.ToString());
        }
        public object ConvertBack(object value, Type targetType, 
        object parameter, CultureInfo culture)
        {
              throw new NotImplementedException();
        }
    }
