    static ClassName() 
    {
        Property = DependencyProperty.Register("PropertyName", typeof(propertyType), typeof(ownerType), 
        new UIPropertyMetadata(new PropertyChangedCallback(PropertyChangedCallback));
    }
    
    static void PropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArts e)
    {
        ClassName class = obj as ClassName;
        // Manipulate properties by accessing them through class.
    }
