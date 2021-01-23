    namespace MyConverters {
        public sealed class OutcomeToColorConverter : IValueConverter {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
                // We must have a valid integer value, double check bindings
                if (value == null) {
                    throw new ArgumentNullException("value", 
                        "Please make sure the value is not null.");
                }
                var OutcomeId = (int)value;
                if (OutcomeId == XXX) { 
                    return RED_BRUSH; 
                }
                else {
                    return BLUE_BRUSH;
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
                throw new NotImplementedException();
            }
            static readonly SolidColorBrush RED_BRUSH = new SolidColorBrush(Colors.Red);
            static readonly SolidColorBrush BLUE_BRUSH = new SolidColorBrush(Colors.Blue);
        }
    }
