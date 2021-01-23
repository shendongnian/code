    public class EnumDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Type t = value.GetType();
            if (t.IsEnum)
            {
                FieldInfo fi = t.GetField(value.ToString());
                DisplayStringAttribute[] attrbs = (DisplayStringAttribute[])fi.GetCustomAttributes(typeof(DisplayStringAttribute),
                    false);
                return ((attrbs.Length > 0) && (!String.IsNullOrEmpty(attrbs[0].Value))) ? attrbs[0].Value : value.ToString();
            }
            else
            {
                throw new NotImplementedException("Converter is for enum types only");
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
