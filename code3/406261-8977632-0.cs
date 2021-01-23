    [ValueConversion(typeof(TextBlock), typeof(bool?))]
    public class ColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TextBlock txtblk = value as TextBlock;
            if (null == txtblk)
                return false;
            // Returns true iff txtblk.Text is non-null and nonempty
            return txtblk.Text != null && !(string.Empty.Equals(txtblk.Text));
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Don't need to use the back conversion
            throw new NotImplementedException();
        }
    }
