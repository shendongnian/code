    public class BooleanSwitchConverter : DependencyObject, IValueConverter
        {
            public object TrueValue
            {
                get { return (object)GetValue(TrueValueProperty); }
                set { SetValue(TrueValueProperty, value); }
            }
            public static readonly DependencyProperty TrueValueProperty =
                DependencyProperty.Register("TrueValue", typeof(object), typeof(BooleanSwitchConverter), new PropertyMetadata(null));
            
            public object FalseValue
            {
                get { return (object)GetValue(FalseValueProperty); }
                set { SetValue(FalseValueProperty, value); }
            }
            public static readonly DependencyProperty FalseValueProperty =
                DependencyProperty.Register("FalseValue", typeof(object), typeof(BooleanSwitchConverter), new PropertyMetadata(null));
            
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return ((bool)value) ? TrueValue : FalseValue;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
