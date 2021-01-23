    public class FixedDateTimeConverter : DateTimeConverter
    {
        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            DateTime d;
            return DateTime.TryParse(value.ToString(), out d);
        }
    }
...
    var converter = TypeDescriptor.GetConverter(typeof (T));
    if (typeof (T) == typeof (DateTime))
        converter = new FixedDateTimeConverter(); 
            
    return converter.IsValid(null,r);
