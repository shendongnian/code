        public class LocationEquipmentConverter : IValueConverter
        {
            public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
            {
                MegaWidget widget = value as MegaWidget;
                string location = (string) parameter;
                return widget?.Locations[ location ]?.Contents;
            }
            public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
            {
                throw new NotImplementedException( );
            }
        }
