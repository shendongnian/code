    public class CustomColorTypeConverter : StringConverter
    {
        static Dictionary<CustomColor, string> _nameIndex = InitializeNameIndex();
        static Dictionary<string, CustomColor> _colorIndex = InitializeColorIndex();
        private static Dictionary<string, CustomColor> InitializeColorIndex()
        {
            return typeof(CustomColor)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .ToDictionary(f => f.Name, f => (CustomColor)f.GetValue(null));
        }
        private static Dictionary<CustomColor, string> InitializeNameIndex()
        {
            return typeof(CustomColor)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .ToDictionary(f => (CustomColor)f.GetValue(null), f => f.Name);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new System.ComponentModel.TypeConverter.StandardValuesCollection(_nameIndex.Values.ToList());
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(CustomColor))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                CustomColor result;
                if (_colorIndex.TryGetValue((string)value, out result))
                    return result;
                else
                    return new CustomColor();
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is CustomColor)
            {
                string result;
                if (_nameIndex.TryGetValue((CustomColor)value, out result))
                    return result;
                else
                    return String.Empty;
            }
            else
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }
