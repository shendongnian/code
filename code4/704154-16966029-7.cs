    public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached(
      "IsFocused",
      typeof(bool),
      typeof(FocusExtension),
      new FrameworkPropertyMetadata(
        false,
        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
        OnIsFocusedPropertyChanged));
