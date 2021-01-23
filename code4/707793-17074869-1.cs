    class NullItem2Visibility:IValueConverter{
        public object Convert(object value, Type type, object parameter, CultureInfo i){
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }
        public object ConvertBack(...){...}
    }
