    [TypeConverter(typeof(MyTypeConverter))]
    public class MinorFrameFormatDefinition
    {
        [Description("Word Number")]
        public int WordNumber { get; set; }
    
        [Description("Number of Bits")]
        public int NumberOfBits { get; set; }
    }
    public class MyTypeConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
                return "hello world";
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
