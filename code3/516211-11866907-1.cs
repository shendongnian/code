    [TypeConverter(typeof(DoubleOrTextConverter))]
    public class DoubleOrText : IComparable
    {
        public double Value { get; private set; }
        public string Text { get; private set; }
        public DoubleOrText(double val, string text)
        {
            this.Value = val;
            this.Text = text;
        }
        public static DoubleOrText FromString(System.Globalization.CultureInfo culture, string str)
        {
            double v;
            if (double.TryParse(str, out v))
                return new DoubleOrText(v, null);
            return new DoubleOrText(0, str);
        }
        public string ToString(System.Globalization.CultureInfo culture)
        {
            if (this.Text != null)
                return this.Text;
            return this.Value.ToString(culture);
        }
        // define your sorting strategy here
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
    
            var other = obj as DoubleOrText;
            if (other != null)
                return this.Value.CompareTo(other.Value);
            else
                throw new ArgumentException("Object is not a DoubleOrText");
        }
    }
    
    public class DoubleOrTextConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
                return DoubleOrText.FromString(culture, value as string);
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var dValue = (DoubleOrText)value;
                return dValue.ToString(culture);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
