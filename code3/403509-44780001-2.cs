    foreach (DataGridViewRow row in dgv.SelectedRows.Count < 2 ? (ICollection) dgv.Rows : dgv.SelectedRows)
    {
        if (dgv.Columns.Contains(column.Name))
        {
            var val = row.Cells[column.Name].Value;
            if (!(val is bool) || !(bool) val)
            {
                allAreTrue = false;
                break;
            }
        }
    }
