    [ValueConversion(typeof(BitmapData), typeof(ImageSource))]
    public class BitmapDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapData data = (BitmapData)value;
            WriteableBitmap bmp = new WriteableBitmap(
                data.Width, data.Height,
                96, 96,
                PixelFormats.Bgr24,
                null);
            int len = data.Height * data.Stride;
            bmp.WritePixels(new System.Windows.Int32Rect(0, 0, data.Width, data.Height), data.Scan0, len, data.Stride, 0, 0);
            return bmp;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
