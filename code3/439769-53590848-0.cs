    public class SelectedItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dg = value as DataGrid;
            return dg?.SelectedItems;
        }
    ...
