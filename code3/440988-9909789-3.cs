    //initialize the strinbuilder
    StringBuilder sb = new StringBuilder();    
    //append the columns to the header row
    string[] columns = new string[dt.Columns.Count - 1];
    for (int i = 0; i < dt.Columns.Count; i++)
        columns[i] = dt.Columns[i].ColumnName;
    sb.AppendLine(string.Join(",", columns));          
    
    foreach (DataRow row in dt.Rows)
    {
        //append the data for each row in the table
        string[] fields = new string[row.ItemArray.Length];
        for (int x = 0; x < myDataRow.ItemArray.Length; x++)        
            arr[x] = row[x].ToString();                
        sb.AppendLine(string.Join(",", fields));
    }
    
    File.WriteAllText("test.csv", sb.ToString());
