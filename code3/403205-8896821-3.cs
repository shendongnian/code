    public static readonly DependencyProperty IsBubbleSourceProperty = 
     DependencyProperty.RegisterAttached(
      "IsBubbleSource",
      typeof(Boolean),
      typeof(AquariumObject),
      new FrameworkPropertyMetadata(false, 
        FrameworkPropertyMetadataOptions.AffectsRender)
    );
    public static void SetIsBubbleSource(UIElement element, Boolean value)
    {
      element.SetValue(IsBubbleSourceProperty, value);
    }
    public static Boolean GetIsBubbleSource(UIElement element)
    {
      return (Boolean)element.GetValue(IsBubbleSourceProperty);
    }
