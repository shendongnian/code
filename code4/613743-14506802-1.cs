    public class RequiredIntConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        [System.Diagnostics.DebuggerNonUserCode]
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                throw new ApplicationException("This field requires an integer value and cannot be blank.");
            }
            int result = 0;
            if (!int.TryParse(value.ToString(), out result))
            {
                throw new ApplicationException("The value could not be parsed as a valid integer data type.");
            }
            else
            {
                return result;
            }
        }
    }
