    public class BinaryToByteArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is System.Data.Linq.Binary)
            {
                byte[] array = (value as System.Data.Linq.Binary).ToArray();
                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream())
                {
                    int offset = 78;
                    stream.Write(array, offset, array.Length - offset);
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
                return bitmap;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
