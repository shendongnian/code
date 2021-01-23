    internal class AnimalConverter : ExpandableObjectConverter {
      public override object ConvertTo(ITypeDescriptorContext context, 
                                       CultureInfo culture, 
                                       object value,
                                       Type destinationType) {
        if (destinationType == typeof(string) && value is Animal) {
          Animal a = (Animal)value;
          return a.ToString();
        }
        return base.ConvertTo(context, culture, value, destinationType);
      }
    }
