    public static readonly DependencyProperty IconVisibilityBoldProperty = 
    DependencyProperty.Register("IconVisibilityBold", typeof(System.Windows.Visibility), typeof(RTFBox));
    public System.Windows.Visibility IconVisibilityBold
    {
     get
     {
      return (System.Windows.Visibility)GetValue(IconVisibilityBoldProperty);
     }
     set
     {
      SetValue(IconVisibilityBoldProperty, value);
     }
    }
