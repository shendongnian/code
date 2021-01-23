    public class MyIdTypeConverter : TypeConverter
    {                
        public override object ConvertFrom(ITypeDescriptorContext context,
                                           System.Globalization.CultureInfo culture,
                                           object value)
        {   
            if (value is int)
                return new MyId((int)value);
            else if (value is MyId)
                return value;
            return base.ConvertFrom(context, culture, value);
        }               
    }
