    private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        if (dataGridView.AllowUserToResizeColumns) //So not to run unnecessarily
        {
            return;
        }
        var lastIndex = dataGridView.Rows.GetLastRow(DataGridViewElementStates.Displayed);
        if (e.RowIndex == lastIndex) //Only do on the last displayed row
        {
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            dataGridView.AllowUserToResizeColumns = true;  // User has control from here on
        }
    }
