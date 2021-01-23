    private void priorityUserControl_PriorityDecreased(object sender, EventArgs e)
    {
        // sender is a control where you clicked Down button
        Control currentControl = (Control)sender;
        // get position in panel
        var position = panel.GetPositionFromControl(currentControl);
        // just to be sure control is not one at the bottom
        if (position.Row == panel.RowCount - 1)
            return;
        // we want to switch with control beneath current        
        Control controlToSwitch = panel.GetControlFromPosition(0, position.Row + 1);
        // move both controls
        panel.SetRow(currentControl, position.Row + 1);
        panel.SetRow(controlToSwitch, position.Row);            
    }
