    public class ExampleConverter : DependencyObject, IValueConverter
    {
        public string Example
        {
            get => GetValue(ExampleProperty).ToString();
            set => SetValue(ExampleProperty, value);
        }
        public static readonly DependencyProperty ExampleProperty =
            DependencyProperty.Register("Example", typeof(string), typeof(ExampleConverter), new PropertyMetadata(null));
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Do the convert
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
