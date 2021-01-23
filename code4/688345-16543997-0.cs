    void EmulateShiftTab()
    {
        // get all form elements that can be focused
        var tabcontrols = this.Controls.Cast<Control>()
                .Where(a => a.CanFocus)
                .OrderBy(a => a.TabIndex);
        // get the last control before the current focused element
        var lastcontrol =
                tabcontrols
                .TakeWhile(a => !a.Focused)
                .LastOrDefault(a => a.TabStop);
        // if no control or the first control on the page is focused,
        // select the last control on the page 
        if (lastcontrol == null)
               lastcontrol = tabcontrols.LastOrDefault();
        // change focus to the proper control
        if (lastcontrol != null)
               lastcontrol.Focus();
    }
