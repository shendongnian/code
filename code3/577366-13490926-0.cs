    public static readonly DependencyProperty SelectedYardIdProperty =
        DependencyProperty.Register(
            "SelectedYardId",
            typeof(long),
            typeof(YardSelectorUserControl),
            new UIPropertyMetadata(OnSelectedYardIdChanged));
    public static void OnSelectedYardIdChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
    }
