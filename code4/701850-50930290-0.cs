    namespace Controls
    {
        [ValueConversion(typeof(String), typeof(ImageSource))]
        public class StringToImageSourceConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (!(value is string valueString))
                {
                    return null;
                }
                try
                {
                    ImageSource image = BitmapFrame.Create(new Uri(valueString), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    return image;
                }
                catch { return null; }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
