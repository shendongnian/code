    [__DynamicallyInvokable]
    public static double ToDouble(object value)
    {
      if (value != null)
        return ((IConvertible) value).ToDouble((IFormatProvider) null);
      else
        return 0.0;
    }
    // common implementation of IConvertable
    double IConvertible.ToDouble(IFormatProvider provider)
    {
      return Convert.ToDouble(this, provider);
    }
    // implementation for string
    [__DynamicallyInvokable]
    public static double ToDouble(string value, IFormatProvider provider)
    {
      if (value == null)
        return 0.0;
      else
        return double.Parse(value, NumberStyles.Float | NumberStyles.AllowThousands, provider);
    }
    // and for long. differs, right? 
    [__DynamicallyInvokable]
    public static double ToDouble(long value)
    {
      return (double) value;
    }
