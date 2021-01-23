    public bool CanSelect {
        // We implement this to allow only AxHost to override canSelectCore, but still
        // expose the method publicly
        //
        get {
            return CanSelectCore();
        }
    }
    internal virtual bool CanSelectCore() {
        if ((controlStyle & ControlStyles.Selectable) != ControlStyles.Selectable) {
            return false;
        }
 
        for (Control ctl = this; ctl != null; ctl = ctl.parent) {
            if (!ctl.Enabled || !ctl.Visible) {
                return false;
            }
        }
 
        return true;
    }
