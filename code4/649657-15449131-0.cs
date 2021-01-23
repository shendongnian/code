    [TypeConverter(typeof (LengthConverter))]
    public double Height
    {
      get
      {
        return (double) this.GetValue(FrameworkElement.HeightProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.HeightProperty, (object) value);
      }
    }
