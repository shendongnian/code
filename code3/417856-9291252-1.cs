    public static readonly DependencyProperty InheritedTextProperty =
        DependencyProperty.Register(
            "InheritedText", typeof(string), typeof(InheritedTextBoxControl),
            new PropertyMetadata(string.Empty, InheritedTextChanged));   
    private static void InheritedTextChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        ((InheritedTextBoxControl)d).inheritedText.Text = (string)e.NewValue;
    }
 
    public string InheritedText
    { 
        get { return (string)GetValue(InheritedTextProperty); } 
        set { SetValue(InheritedTextProperty, value); } // only call SetValue here
    } 
