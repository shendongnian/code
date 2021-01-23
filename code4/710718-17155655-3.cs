    internal virtual bool CanSelectCore()
    {
        if ((this.controlStyle & ControlStyles.Selectable) != ControlStyles.Selectable)
        {
            return false;
        }
        for (Control control = this; control != null; control = control.parent)
        {
            if (!control.Enabled || !control.Visible)
            {
                return false;
            }
        }
        return true;
    }
