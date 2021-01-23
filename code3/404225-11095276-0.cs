     public class CaseInsensitiveEnumConfigConverter<T> : ConfigurationConverterBase
        {
            public override object ConvertFrom(
            ITypeDescriptorContext ctx, CultureInfo ci, object data)
            {
                return Enum.Parse(typeof(T), (string)data, true);
            }
        }
