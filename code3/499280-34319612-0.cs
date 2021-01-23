    class EscapingFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            var escape = false;
            if (format.StartsWith("!"))
            {
                escape = true;
                format = format.Substring(1);
            }
            var formattable = arg as IFormattable;
            var formatted = formattable == null
                ? arg.ToString()
                : formattable.ToString(format, formatProvider);
            return escape ? HttpUtility.HtmlEncode(formatted) : formatted;
        }
    }
