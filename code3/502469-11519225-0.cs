    [ValueConversion(typeof(System.Drawing.Imaging.BitmapData), typeof(ImageSource))]
    public class BitmapDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Drawing.Imaging.BitmapData data = (System.Drawing.Imaging.BitmapData)value;
            WriteableBitmap bitmap = new WriteableBitmap(data.Width, data.Height, ...);
            bitmap.WritePixels(...);
            return bitmap;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
