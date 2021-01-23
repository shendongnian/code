    namespace YourApp.Util.Converters
    {
        [ValueConversion(typeof(bool), typeof(Cursor))]
        public class BoolToCursorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
            {
    			var val = (bool)value;
    			if (val)
    				return Cursors.WaitCursor;
    			return Cursors.Arrow;
    		}
    
            public object ConvertBack(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
