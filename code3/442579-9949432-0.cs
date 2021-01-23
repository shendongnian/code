    public class ImageConverter : IValueConverter
    {
    /// <summary>
    /// Converts a Jpeg byte array into a WriteableBitmap
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is byte[])
        {
            MemoryStream stream = new MemoryStream((Byte[])value);
            WriteableBitmap bmp = PictureDecoder.DecodeJpeg(stream);
            return bmp;
        }
        else
            return null;
    }
    /// <summary>
    /// Converts a WriteableBitmap into a Jpeg byte array.
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    }
