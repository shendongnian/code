    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MyCustomControl myCustomControl = (MyCustomControl)d;
        myCustomControl.Text = (string) e.NewValue;
    }
