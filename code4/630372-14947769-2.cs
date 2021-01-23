    public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register("SelectedItem", typeof(string), typeof(MainWindow), 
        new UIPropertyMetadata(string.Empty,new PropertyChangedCallback(PropertyChanged),
        new CoerceValueCallback(CoerceValue)));
    private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    }
    private static object CoerceValue(DependencyObject d, object baseValue)
    {
        if (baseValue != WhatIWasExpecting)
        {
            return WhatIWant;
        }
        return baseValue;
    }
