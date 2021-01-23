    public class CoordinateToPathSegment : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var coordinate = value as CurveViewModel.Coordinate;
            var segment = new QuadraticBezierSegment();
    
            // Set properties of quadratic bezier element
    
            return segment;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
