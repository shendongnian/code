    public class GeometryCenterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = new TranslateTransform();
            var geometry = value as Geometry;
            if (geometry != null)
            {
                result.X = (geometry.Bounds.Left + geometry.Bounds.Right) / 2;
                result.Y = (geometry.Bounds.Top + geometry.Bounds.Bottom) / 2;
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
