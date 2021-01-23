    public class CustomNumberTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, 
                                            Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, 
            CultureInfo culture, object value)
        {            
            if (value is string)
            {
                string s = (string)value;
                return Int32.Parse(s, NumberStyles.AllowThousands, culture);
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, 
            CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
                return ((int)value).ToString("N0", culture);
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
