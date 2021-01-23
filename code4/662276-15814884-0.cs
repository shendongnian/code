    public class ImagePathConverter : IValueConverter
    {     
        public object Convert(object value, Type targetType, object parameter)
        {
            if(value == null) return null;
            Uri uri = new Uri(value.ToString(), UriKind.AbsoluteOrRelative);
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(uri);
            return ib;
        }
 
        public object ConvertBack(object value, Type targetType, object parameter)
        {
            throw new NotImplementedException();
        }
    }
     
