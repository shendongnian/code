    [ValueConversion(typeof(DataGridCellInfo), typeof(bool))]
    public sealed class DataGridCellInfoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(DataGridCellInfo) || targetType != typeof(bool))
                return DependencyProperty.UnsetValue;
            // IsValid will be false, if there's no focused cell.
            return ((DataGridCellInfo)value).IsValid;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
