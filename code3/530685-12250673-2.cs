    public class LocalizedBoolFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            bool value = (bool)arg;
            format = (format == null ? null : format.Trim().ToLower());
            switch (format)
            {
                case "yn":
                    return GetLocalizedBool(value);
                default:
                    return HandleDefaultFormat(arg, format, formatProvider);
            }
        }
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
    }
