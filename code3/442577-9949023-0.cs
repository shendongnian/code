     public class ByteArraytoImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null) return null;
    
                var byteBlob = value as byte[];
                var ms = new MemoryStream(byteBlob);
                var bmi = new BitmapImage();
                bmi.SetSource(ms);
                return bmi;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
