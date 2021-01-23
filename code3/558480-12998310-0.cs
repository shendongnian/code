    object[] objArrRestrict;
    objArrRestrict = new object[] {null, null, "Customers", null};
    DataTable schemaCols;
    schemaCols = con.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, objArrRestrict);
    //List the schema info for the selected table
    foreach (DataRow row in schemaCols.Rows)
    {
    listBox.Items.Add(row["COLUMN_NAME"]);
    }
