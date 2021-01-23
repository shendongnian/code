    public enum ControlState
    {
        Unknown = 0,
        DateInPast,
        DateInFuture
    }
    
    ....
    
    var state = ControlState.Unknown;
    
    if (SelectedDateIsInThePast() && (!currentlyReadOnly)) {
        state = ControlState.DateInPast;
    } else if (!SelectedDateIsInThePast() && (currentlyReadOnly)) {
        state = ControlState.DateInFuture;
    }
    if (state != ControlState.Unknown) {
        foreach (Control ctrl in tableLayoutPanelPlatypus.Controls) {
            if (ctrl is TextBox) {
                tb = (TextBox)ctrl;
                tb.ReadOnly = setReadOnlyToTrue.Value;
            }
        }
    }
