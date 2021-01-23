    DependencyProperty SomeProperty = DependencyProperty.Register(
        "Some",
        propertyType,
        ownerType,
        new FrameworkPropertyMetadata(defaultValue, OnSomePropertyChanged));
    static void OnSomePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        // "d" is your instance here, cast it to the required type
    }
