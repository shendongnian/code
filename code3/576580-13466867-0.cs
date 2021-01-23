    public void AddHeaderText(DataGridViewColumn column)
    {
        column.HeaderText = headerName;
        column.Name = "col" + headerName;
        dgvMain.Columns.Add(column);
    }
