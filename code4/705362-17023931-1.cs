    public class ValueConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty CandidateValueProperty = DependencyProperty.Register("CandidateValue", typeof(string), typeof(ValueConverter));
        public string CandidateValue
        {
            get { return (string)GetValue(CandidateValueProperty); }
            set { SetValue(CandidateValueProperty, value); }
        }
        public ValueConverter()
            : base()
        { 
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value)
            {
                if (value.ToString() == this.CandidateValue)
                    return true;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
