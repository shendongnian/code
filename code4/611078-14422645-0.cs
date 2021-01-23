    public static readonly DependencyProperty ShowChildItemsProperty =
        DependencyProperty.Register("showChildItems", typeof (bool), typeof (MyUserControl), new PropertyMetadata(true));
    public bool ShowChildItems
    {
        get { return (bool) GetValue(ShowChildItemsProperty); }
        set { SetValue(ShowChildItemsProperty, value); }
    }
