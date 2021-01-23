    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register(
            "TheItems", // This is wrong
            typeof(ItemCollection),
            typeof(AutocompleteTextBox),
            new PropertyMetadata(default(ItemCollection), OnItemsPropertyChanged));
