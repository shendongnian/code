    [ValueConversion( typeof( Func<int> ), typeof( string ) )]
    public class FnConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            Func<int> fn = value as Func<int>;
            return fn.Method.Name;
        }
        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            return null;
        }
    }
