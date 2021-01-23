    public static void AddColumn<TCol>(this DataGridView dgv, string headerName) 
        : where TCol : DataGridViewColumn, new()
    {
       var col = new TCol();
       col.HeaderText = headerName;
       col.Name = "col" + headerName;
       dgv.Columns.Add(col); 
    }
