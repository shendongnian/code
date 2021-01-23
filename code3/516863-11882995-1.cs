    // Method 1 
    dt.Columns.Add ("column0", System.Type.GetType ("System.String")); 
    // Method 2 
    DataColumn dc = new DataColumn("column1",System.Type.GetType("System.Boolean")); 
    dt.Columns.Add (dc);
 
