    public class DefaultForNullOrWhiteSpaceStringConverter : IValueConverter
    {
        public string DefaultValue
        {
            get { return (string)GetValue(DefaultValueProperty); }
            set { SetValue(DefaultValueProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for DefaultValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultValueProperty =
            DependencyProperty.Register("DefaultValue", typeof(string), 
            typeof(DefaultForNullOrWhiteSpaceStringConverter), new PropertyMetadata(null));
    ...
    ...
