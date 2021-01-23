    class BarConverter : TypeConverter
    {
      public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
      {
        return true;
      }
      public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
      {
        return new StandardValuesCollection(barlist);
      }
      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
        if (sourceType == typeof(string))
        {
          return true;
        }
        return base.CanConvertFrom(context, sourceType);
      }
      public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
      {
        if (value is string)
        {
          foreach (Bar b in barlist)
          {
            if (b.barvalue == (string)value)
            {
              return b;
            }
          }
        }
        return base.ConvertFrom(context, culture, value);
      }
    }
