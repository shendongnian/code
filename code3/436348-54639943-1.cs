    public class ContentGeneratorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var control = new ContentControl {ContentTemplate = (DataTemplate) parameter};
            control.SetBinding(ContentControl.ContentProperty, new Binding());
            return control;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
