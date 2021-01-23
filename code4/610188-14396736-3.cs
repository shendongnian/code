    public class ThemeImageConverterClockShadow : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dataItem = value as MyDataItem;
            if (dataItem != null)
            {
               // Use dataItem.Time and dataItem.ShadowType to select an image
            }
        }
    }
