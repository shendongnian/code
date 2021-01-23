    for (int i = RequestedEmpGrid.Rows.Count; i >= 0; i--)
    {
        var row = RequestedEmpGrid.Rows[i];
        if (Convert.ToBoolean(row.Cells[MarkColumn.Name].Value))
        {
            RequestedEmpGrid.Rows.RemoveAt(i);
        }
    }
