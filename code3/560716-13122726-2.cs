    public class WhiteSpaceToNullableTypeConverter<T> : TypeConverter where T : struct
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof (string);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof (T?);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture,
                                           object value)
        {
            T? result = null;
            var stringValue = (string) value;
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                result = (T)converter.ConvertFrom(stringValue.Trim());
            }
            return result;
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture,
                                         object value, Type destinationType)
        {
            var result = (T?) value;
            return result.ToString();
        }
    }
