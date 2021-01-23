    public static readonly DependencyProperty IconVisibilityBoldProperty = 
    DependencyProperty.Register("IconVisibilityBold", typeof(Visibility), typeof(RTFBox),
    new PropertyMetadata(Visibility.Hidden), VisibilityValidateCallback);
    private static bool VisibilityValidateCallback(object value)
    {
     Visibility prop = (Visibility) value;
     if (prop == Visibility.Hidden || prop == Visibility.Visible)
     {
      return true;
     }
     return false;
    }
    public Visibility IconVisibilityBold
    {
     get
     {
      return IconVisibilityBoldProperty;
     }
     set
     {
      IconVisibilityBoldProperty = value;
     }
    }
