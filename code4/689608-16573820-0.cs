    public string TextBoxText
    {
        get { return (string)GetValue(TextBoxTextProperty); }
        set { SetValue(TextBoxTextProperty, value); }
    }
    public static readonly DependencyProperty TextBoxTextProperty =
        DependencyProperty.Register("TextBoxText", typeof(string), typeof(MyUserControl),
        new PropertyMetadata(string.Empty, OnTextBoxTextPropertyChanged));
    private static void OnTextBoxTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as MyUserControl).MyTextBox.Text = e.NewValue.ToString();
    }
