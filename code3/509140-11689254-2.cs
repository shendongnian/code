    public class CustomFormatter : IFormatProvider, ICustomFormatter
    {
        public CultureInfo Culture { get; private set; }
        public CustomFormatter()
            : this(CultureInfo.CurrentCulture)
        { }
        public CustomFormatter(CultureInfo culture)            
        {
            this.Culture = culture;
        }
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (formatProvider.GetType() == this.GetType())
            {
                return string.Format(this.Culture, "{0:0.00}", arg).Replace(this.Culture.NumberFormat.NumberDecimalSeparator + "00", "");
            }
            else
            {
                if (arg is IFormattable)
                    return ((IFormattable)arg).ToString(format, this.Culture);
                else if (arg != null)
                    return arg.ToString();
                else
                    return String.Empty;
            }
        }
    }
