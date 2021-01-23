    public static void AddColumn<TCol>(this DataGridView dgv, string headerName) 
        where TCol : DataGridViewColumn, new()
    {
       var col = new TCol {
           HeaderText = headerName,
           Name = "col" + headerName,
       }
       dgv.Columns.Add(col); 
    }
