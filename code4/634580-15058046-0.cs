    public class ImageBytesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            if (value != null)
            {
                byte[] photo = ((System.Data.Linq.Binary)value).ToArray();
                using(MemoryStream stream = new MemoryStream())
                {
                    int offset = 78;
                    stream.Write(photo, offset, photo.Length - offset);
                    
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
            
                return bitmap;
            }
        }
    }
