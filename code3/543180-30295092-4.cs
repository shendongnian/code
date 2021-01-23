    protected override void OnActivated(EventArgs e)
    {
        if (DesignerProperties.GetIsInDesignMode(this))
            return;
        base.Owner.Activate();
    }
