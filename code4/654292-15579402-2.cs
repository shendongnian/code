    <local:WidthConverter x:Key="widthConverter"/>
    <GridViewColumn Width="{Binding ElementName=lvCurDocFields, Path=ActualWidth, Converter={StaticResource widthConverter}, ConverterParameter=100}">
   
     [ValueConversion(typeof(double), typeof(double))]
        public class WidthConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                // value is the total width available
                double otherWidth;
                try
                {
                    otherWidth = System.Convert.ToDouble(parameter);
                }
                catch
                {
                    otherWidth = 100;
                }
                if (otherWidth < 0) otherWidth = 0;
        
                double width = (double)value - otherWidth;
                if (width < 0) width = 0;
                return width; // columnsCount;
            }
        
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
