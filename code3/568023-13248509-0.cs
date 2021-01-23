    //Append column names
    builder.Append(String.Join(",", 
        from DataColumn c in dataTable.Columns
        select c.ColumnName
    )).Append("\n");
    //Append data from datatable
    builder.Append(string.Join("\n", 
        from DataRow row in dataTable.Rows
        select String.Join("\n", 
            String.Join(",", row.ItemArray)
        )
    ));
    Response.Clear();
    Response.ContentType = "text/csv";
    Response.AddHeader("Content-Disposition", "attachment;filename=myfilename.csv");
    Response.Write(builder.ToString());
    Response.End();
