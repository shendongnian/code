    public static readonly DependencyProperty DataContextProperty = 
        DependencyProperty.Register("DataContext", typeof(object),
        FrameworkElement._typeofThis,
        (PropertyMetadata) new FrameworkPropertyMetadata((object)null,
            FrameworkPropertyMetadataOptions.Inherits,
            new PropertyChangedCallback(FrameworkElement.OnDataContextChanged)));
