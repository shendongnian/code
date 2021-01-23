    public class ValueConverterBase : IValueConverter {
    public virtual object Convert (object value, Type convertTargetType, object convertParameter, System.Globalization.CultureInfo convertCulture) {
            return value;
        }
        public virtual object ConvertBack (object value, Type convertBackTargetType, object convertBackParameter, System.Globalization.CultureInfo convertBackCulture) {
            return value;
        }
    }
