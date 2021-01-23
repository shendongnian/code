    public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register("SelectedItem", typeof (int), typeof (WeightSet), new PropertyMetadata(default(int)));
    public int SelectedItem {
        get { return (int) GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }
