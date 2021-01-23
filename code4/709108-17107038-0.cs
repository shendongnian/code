        public class MyImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string imageName = (string) value;
                return new BitmapImage(new Uri("../../images/" + imageName + ".png", UriKind.Relative));
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
