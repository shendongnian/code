    public class ToAndFromStringTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }
    }
    public class LocalDateTypeConverter : ToAndFromStringTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                DateTime parsed;
                if (!DateTime.TryParse((string)value, out parsed))
                    throw new ArgumentException("Cannot convert '" + (string)value + "' to LocalDate.");
                else
                    return new LocalDate(parsed.Year, parsed.Month, parsed.Day);
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var tvalue = (LocalDate)value;                
                try
                {
                    var x = tvalue.ToString("yyyy-MM-dd");
                    return x;
                }
                catch (NullReferenceException)
                {
                    return "1900-1-1";
                }
                catch
                {
                    throw new ArgumentException("Could not convert '" + value.ToString() + "' to LocalDate.");
                }                
            } 
            else 
                return base.ConvertTo(context, culture, value, destinationType);
        }
    public class InstantTypeConverter : ToAndFromStringTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    DateTime parsed = DateTime.Parse((string)value);
                    LocalDateTime dt = LocalDateTime.FromDateTime(parsed);
                    Instant i = dt.InZoneLeniently(DateTimeZoneProviders.Default.GetSystemDefault()).ToInstant();
                    return i;
                }
                catch
                {
                    throw new ArgumentException("Cannot convert '" + (string)value + "' to Instant.");
                }
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                try
                {
                    Instant tvalue = (Instant)value;
                    LocalDateTime local = tvalue.InZone(DateTimeZoneProviders.Default.GetSystemDefault()).LocalDateTime;
                    string output = LocalDateTimePattern.CreateWithInvariantCulture("yyyy-MM-dd HH:mm:ss.FFFFFF").Format(local);
                    return output;
                }
                catch
                {
                    throw new ArgumentException("Could not convert '" + value.ToString() + "' to LocalDate.");
                }                    
            }
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }
    }
