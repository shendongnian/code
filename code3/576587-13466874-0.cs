    private void yourMethode(DataGridViewColumn col)
    {
       col.HeaderText = headerName;     
       col.Name = "col" + headerName;   
       dgvMain.Columns.Add(col);   
    }
