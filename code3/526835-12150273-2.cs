    DataTable table = new DataTable("ImageTable"); //Create a new DataTable instance.
    DataColumn column0 = new DataColumn("id"); //Create the column.
    column.DataType = System.Type.GetType("System.String"); //Type string 
    DataColumn column1 = new DataColumn("image"); //Create the column.
    column.DataType = System.Type.GetType("System.Byte[]"); //Type byte[] to store image bytes.
    column.AllowDBNull = true;
    column.Caption = "My Image";
    
    table.Columns.Add(column0); //Add the column to the table.
    table.Columns.Add(column1); //Add the column to the table.
    Then, add a new row to this table and set the value of the MyImage column.
    
    DataRow row = table.NewRow();
    row["MyImage"] = <Image byte array>;
    tables.Rows.Add(row);
