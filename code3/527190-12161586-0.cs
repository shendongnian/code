    DataTable table = myReader.GetSchemaTable();
    
    foreach (DataRow myField in table.Rows)
    {
        foreach (DataColumn myProperty in table.Columns)
        {
            fileconnectiongrid.Rows.Add(myProperty.ToString());
        }
    }
