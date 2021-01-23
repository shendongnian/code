    protected override void OnMouseEnter(MouseEventArgs e)
    {
        VisualStateManager.GoToState(this, "BorderHighlight, false);
        ...
    }
    protected override void OnMouseLeave(MouseEventArgs e)
    {
        VisualStateManager.GoToState(this, "BorderNormal, false);
        ...
    }
