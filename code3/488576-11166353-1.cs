     public static void SetColumns(DataGridView dgv)
     {
        foreach(DataGridViewColumn column in dgv.Columns)
        {
           column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
     }
