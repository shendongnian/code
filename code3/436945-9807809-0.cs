    public class BytesToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            MemoryStream stream = new MemoryStream((Byte[])value);
            WriteableBitmap bmp = new WriteableBitmap(173, 173);
            bmp.LoadJpeg(stream);
            return bmp;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                    System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
