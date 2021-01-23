    public static readonly DependencyProperty WatermarkTextProperty =
        DependencyProperty.Register("WatermarkTextProperty", typeof(String),
        typeof(WatermarkTextBox), new PropertyMetadata(null));
    public String WatermarkText
    {
        get { return watermarkTextBox.Text; }
        set { watermarkTextBox.Text = value; }
    }
