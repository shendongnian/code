    protected override void OnTextChanged(EventArgs e)
    {
        SetCurrentValue(DocumentTextProperty, base.Text);
        base.OnTextChanged(e);
    }
