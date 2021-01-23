    // create user control and attach event handlers 
    PriorityUserControl control = new PriorityUserControl();
    control.PriorityMaximized += priorityUserControl_PriorityMaximized;
    control.PriorityMinimized += priorityUserControl_PriorityMinimized;
    control.PriorityIncreased += priorityUserControl_PriorityIncreased;
    control.PriorityDecreased += priorityUserControl_PriorityDecreased;
    // add another row to table
    panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
    panel.RowCount = panel.RowStyles.Count;
    // add control table layout panel
    panel.Controls.Add(control);
    panel.SetRow(control, panel.RowCount - 1);
