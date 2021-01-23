    foreach(DataRow row in objDataset1.Tables[0].Rows)
    {
        foreach(DataColumn col in objDataset1.Tables[0].Columns)
        {
            Response.Write(row[col.ColumnName].ToString());
        }
        Response.Write(count++ + "<br>");
    }
