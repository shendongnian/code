    public void AddColumnHeader(DataGridViewColumn column, string headerName)
    {
        column.HeaderText = headerName;
        column.Name = "col" + headerName;
        dgvMain.Columns.Add(column);
    }
