    internal class FilterConverter : TypeConverter
    {
        public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo (context, destinationType);
        }
        public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) && value is Filter)
            {
                ConstructorInfo constructor = typeof (Filter).GetConstructor (new[] {typeof (string), typeof (string)});
                var filter = value as Filter;
                var descriptor = new InstanceDescriptor (constructor, new[] {filter.Name, filter.Value}, true);
                return descriptor;
            }
            return base.ConvertTo (context, culture, value, destinationType);
        }
    }
