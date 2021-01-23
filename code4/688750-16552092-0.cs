    public class BoolToImageConverter: DependencyObject, IValueConverter
    {
        
        public BitmapImage TrueImage
        {
            get { return (BitmapImage)GetValue(TrueImageProperty); }
            set { SetValue(TrueImageProperty, value); }
        }
        public static DependencyProperty TrueImageProperty = DependencyProperty.Register("TrueImage", typeof(BitmapImage), typeof(BoolToImageConverter), null);
        
        public BitmapImage FalseImage
        {
            get { return (BitmapImage)GetValue(FalseImageProperty); }
            set { SetValue(FalseImageProperty, value); }
        }
        public static DependencyProperty FalseImageProperty = DependencyProperty.Register("FalseImage", typeof(BitmapImage), typeof(BoolToImageConverter), null);
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? TrueImage : FalseImage;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var img = (BitmapImage)value;
            return img.UriSource.AbsoluteUri == TrueImage.UriSource.AbsoluteUri;
        }
    }
