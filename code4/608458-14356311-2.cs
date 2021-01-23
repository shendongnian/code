    namespace MyConverters {
        public sealed class OutcomeToColorConverter : IValueConverter {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
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
