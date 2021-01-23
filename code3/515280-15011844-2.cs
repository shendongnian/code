    private void myDataGrid_OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == myCheckBoxColumn.Index && e.RowIndex != -1)
        {
            // Handle checkbox state change here
        }
    }
