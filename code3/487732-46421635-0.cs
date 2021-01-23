    public class SelectedItemsMerger : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            SelectedItemsContainer sic = values[1] as SelectedItemsContainer;
            if (sic != null)
                sic.SelectedItems = values[0];
            return values[0];
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { value };
        }
    }
