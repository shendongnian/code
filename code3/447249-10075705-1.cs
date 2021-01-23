    public class RectangleToGeometryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var rect = value as Rectangle;
            if (rect == null || targetType != typeof(Geometry))
            {
                return null;
            }
            return new RectangleGeometry(new Rect(new Size(rect.Width, rect.Height)))
            { 
                RadiusX = rect.RadiusX, 
                RadiusY = rect.RadiusY 
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
