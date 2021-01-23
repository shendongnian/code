    public bool AnyNumericErrors
    {
      get { return (bool)GetValue(AnyNumericErrorsProperty); }
      set { SetValue(AnyNumericErrorsProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for AnyNumericErrors.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty AnyNumericErrorsProperty =
        DependencyProperty.Register("AnyNumericErrors", typeof(bool), typeof(NumericUpDown), new UIPropertyMetadata(false));
