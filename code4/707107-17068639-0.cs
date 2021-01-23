    class SizeSpacingToCircleGroupConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values == null) return values;
            var input = values.OfType<double>().ToArray();
            if (input.Length != 3) return values;
            var width = input[0];
            var height = input[1];
            var spacing = input[2];
            var halfSpacing = spacing / 2;
            var diameter = width > height ? height : width;
            var lineCount = (int)Math.Floor((diameter / (2 * spacing)) - 1);
            if (lineCount <= 0) return values;
            var circles = Enumerable.Range(0, lineCount).Select(i =>
            {
                var radius = halfSpacing + (i * spacing);
                return new EllipseGeometry() { RadiusX = radius, RadiusY = radius };
            }).ToArray();
            var group = new GeometryGroup();
            foreach (var circle in circles) group.Children.Add(circle);
            return group;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
