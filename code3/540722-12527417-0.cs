    public class WidthToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var width = (double)value;
            var result = new DrawingBrush();
            var group = new DrawingGroup();
            result.Drawing = group;
            group.Children.Add(new ImageDrawing(new BitmapImage(new Uri(@"Resources\Left.png", UriKind.Relative)), new Rect(0, 0, 16, 16)));
            group.Children.Add(new ImageDrawing(new BitmapImage(new Uri(@"Resources\Centre.png", UriKind.Relative)), new Rect(16, 0, width, 16)));
            group.Children.Add(new ImageDrawing(new BitmapImage(new Uri(@"Resources\Right.png", UriKind.Relative)), new Rect(16 + width, 0, 16, 16)));
            return result;
        }
