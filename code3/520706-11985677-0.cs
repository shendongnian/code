    foreach (DataGridViewRow row in myGrid.Rows)
    {
        if (row.Cells["ConditionalColumn"].Value == null || (bool)row.Cells["ConditionalColumn"].Value == false)
        {
            row.ReadOnly = false;
        }
        else
        {
            row.ReadOnly = true;
        }
    }
