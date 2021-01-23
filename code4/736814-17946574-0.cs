    public static readonly DependencyProperty ItemTemplateProperty =
        DependencyProperty.Register("ItemTemplate",
                                    typeof(DataTemplate),
                                    typeof(AutoCompleteSearchBox),
                                    new PropertyMetadata(ItemTemplate_Changed));
    public DataTemplate ItemTemplate
    {
        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        set { SetValue(ItemTemplateProperty, value); }
    }
    private static void ItemTemplate_Changed(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var uc = (MyUserControl)d;
        uc._listBox.ItemTemplate = (DataTemplate)e.NewValue;
    }
