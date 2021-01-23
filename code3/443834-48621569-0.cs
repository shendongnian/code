    [TypeConverter(typeof(StrListConverter))]
    public class StrList : List<string>
    {
        public StrList(IEnumerable<string> collection) : base(collection) {}
    }
    public class StrListConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
                return null;
            if (value is string s)
            {
                if (string.IsNullOrEmpty(s))
                    return null;
                return new StrList(s.Split(','));
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
