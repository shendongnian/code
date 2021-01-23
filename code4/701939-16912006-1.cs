    List<DataTable> sourceTables = getYourSourceTablesMethod();
    if (sourceTables.Length>0)
    {
        DataTable destTable = sourceTables[0].Copy();  
        for (int i = 1; i < sourceTables; i++) 
        {
           foreach (DataRow drow in sourceTables[i].Rows) 
           destTable.Rows.Add(drow.ItemArray);
        }
    }
