    public class BoolStateConverter : BindableObject, IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (bool)value;
            return boolValue ? EnabledValue : DisabledValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public static BindableProperty EnabledValueProperty = BindableHelper.CreateProperty<string>(nameof(EnabledValue));
        public string EnabledValue
        {
            get => (string)GetValue(EnabledValueProperty);
            set => SetValue(EnabledValueProperty, value);
        }
        public static BindableProperty DisabledValueProperty = BindableHelper.CreateProperty<string>(nameof(DisabledValue));
        public string DisabledValue
        {
            get => (string)GetValue(DisabledValueProperty);
            set => SetValue(DisabledValueProperty, value);
        }
    }
