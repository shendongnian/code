    [Bindable(true), Category("Appearance")]
    public Brush Background
    {
       	get
	{
		return (Brush)base.GetValue(Control.BackgroundProperty);
	}
	set
	{
		base.SetValue(Control.BackgroundProperty, value);
	}
    }
