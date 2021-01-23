    if (dgDisplay.InvokeRequired)
    {
        dgDisplay.Invoke(addColumnDelegate, columnDataGridTextBox);
    }
    else
    {
        dgDisplay.Columns.Add(columnDataGridTextBox);
    }
