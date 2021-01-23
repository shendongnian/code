    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown),
        new PropertyMetadata(1000, (sender, e) => (sender as NumericUpDown).ValueText.Text = e.NewValue.ToString()));
    public int Value
    {
        get { return (int)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
