    public static readonly DependencyProperty InnerContentProperty =
                DependencyProperty.Register("InnerContent", typeof (FrameworkElement), typeof (YourControlType),
                                            new FrameworkPropertyMetadata(default(FrameworkElement),
                                                                          FrameworkPropertyMetadataOptions.AffectsRender));
    
            public FrameworkElement InnerContent
            {
                get { return (FrameworkElement) GetValue(InnerContentProperty); }
                set { SetValue(InnerContentProperty, value); }
            }
