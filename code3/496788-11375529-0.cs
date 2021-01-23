    public Color Value
    {
      get
      {
        return (Color)this.GetValue(ValueProperty);
      }
      set
      {
        this.SetValue(ValueProperty, value);
      }
    }
    public static readonly DependencyProperty ValueProperty =
      DependencyProperty.Register("Value", typeof(Color),
      typeof(ColorSlider), new PropertyMetadata(Colors.Red));
