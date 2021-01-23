    public static readonly DependencyProperty SelectedItemsExProperty =
        DependencyProperty.Register(
            "SelectedItemsEx", typeof(IEnumerable), typeof(MyListBox));
    public IEnumerable SelectedItemsEx
    {
        get { return (IEnumerable)GetValue(SelectedItemsExProperty); }
        set { SetValue(SelectedItemsExProperty, value); }
    }
