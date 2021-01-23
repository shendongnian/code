    private void priorityUserControl_PriorityMaximized(object sender, EventArgs e)
    {
        Control currentControl = (Control)sender;
        var position = panel.GetPositionFromControl(currentControl);
        if (position.Row == 0 || panel.RowCount < 2)
            return;
        Control topControl = panel.GetControlFromPosition(0, 0);
        panel.SetRow(currentControl, 0);
        panel.SetRow(topControl, position.Row);  
    }
