    public SmartComboBox()
    {
        base.IsEditable = true;
        base.IsTextSearchEnabled = false;
        ...
    }
    public new bool IsEditable { get { return base.IsEditable; } }
    public new bool IsTextSearchEnabled { get { return base.IsTextSearchEnabled; } }
