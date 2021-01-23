    public class MyStringConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
    
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }
    
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string svalue = value as string;
            if (svalue != null)
                return RemoveSpaceAndLowerFirst(svalue);
    
            return base.ConvertFrom(context, culture, value);
        }
    
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            string svalue = value as string;
            if (svalue != null)
                return RemoveUnderscoreAndUpperFirst(svalue);
    
            return base.ConvertTo(context, culture, value, destinationType);
        }
    
        private static string RemoveSpaceAndLowerFirst(string s)
        {
            // do your format conversion here
        }
    
        private static string RemoveUnderscoreAndUpperFirst(string s)
        {
            // do your format conversion here
        }
    }
