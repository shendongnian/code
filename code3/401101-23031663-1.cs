    public class ShowSuitablePart : IValueConverter
        {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "{DataGrid.NewItemPlaceholder}")
                return "This is blank row, just click me to create a new one";
            else
                ((YourCollectionObject)value).SomeProperty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }
