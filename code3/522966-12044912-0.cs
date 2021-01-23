    ...
    
    //Formatting
    foreach(DataGridViewColumn dgvcol in dgViews["one"].Columns)
    {
         ColumnBLO colB = columns.First(x => x.Label == dgvcol.HeaderText);
         dgvcol.DefaultCellStyle.BackColor = Color.FromName(colB.BackColor);
         dgvcol.DefaultCellStyle.ForeColor = Color.FromName(colB.ForeColor);
    }
    
    ...
