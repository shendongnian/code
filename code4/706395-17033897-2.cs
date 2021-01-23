    public class ConvertFileImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             if (value as string == string.Empty) return null;
    
             var file = @"Media/file_" + Path.GetExtension(value.ToString()) + ".png";
             ImageSource src = new BitmapImage(new Uri(file, UriKind.Relative));
             return src;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
                throw new NotImplementedException();
        }
    }
