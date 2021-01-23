    public Control TargetControl
    {
        get { return (Control)this.GetValue(TargetControlProperty); }
        set { this.SetValue(TargetControlProperty, value); } 
    }
    public static readonly DependencyProperty TargetControlProperty =
        DependencyProperty.Register("TargetControl",
                                    typeof(Control),
                                    typeof(NumericButtonsControl),
                                    new PropertyMetadata(null));
