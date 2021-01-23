    DataTable dt = ToDataTable(your list); // Get DataTable From List
    
    dt.Columns.Add(new Column("StatusText", typeof(string))); // Add New Column StatusText
    
    //Iterate All Rows 
    foreach(DataRow row in dt.Rows)
    {
       //Check Status value, and set StatusText accordingly. 
       row["StatusText"] = int.Parse(row["Status"])==1 ? "InActive" : "Active";
    }
