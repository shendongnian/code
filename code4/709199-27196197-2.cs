    public class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || !(value is byte[]))
                return null;
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes((byte[])value);
                    writer.StoreAsync().GetResults();
                }
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);
                return image;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)                                                                         
        {
            throw new NotImplementedException();
        }
