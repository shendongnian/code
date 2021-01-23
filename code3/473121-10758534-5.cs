    public override ControlCollection Controls
    {
        get
        {
            EnsureChildControls();
            return base.Controls;
        }
    }
