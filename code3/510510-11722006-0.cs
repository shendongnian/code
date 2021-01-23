    //Build Column
        DataColumn column = new DataColumn("MyImage"); 
        column.DataType = System.Type.GetType("System.Byte[]"); //Type byte[] to store image bytes.
        column.AllowDBNull = true;
        column.Caption = "My Image";
        
        //Add Column
        yourDataTable.Columns.Add(column); 
            
        //Build row
        DataRow row = table.NewRow();
        row["MyImage"] = <Image byte array>;
        yourDataTable.Rows.Add(row);
