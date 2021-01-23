    //create an instance of a table
    System.Data.DataTable DT = new System.Data.DataTable();
    //dynamically add columns
    DT.Columns.Add("Column1");
    DT.Columns.Add("Column2");
    DT.Columns.Add("Column3");
    .
    .
    .
    DT.Columns.Add("Column60");
    //this is how you add rows to it
    DT.Rows.Add("val1", "val2", "val3",...."val60");
    
    //this is how you retrieve it
    foreach (DataRow row in DT.Rows)
    {
       Console.Writeline(row[0].toString()); //returns the first column for each iteration
    }
