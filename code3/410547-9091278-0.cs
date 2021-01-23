    public  DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
    {
    DataTable datatable = new DataTable();
    DataTable schemaTable = dataReader.GetSchemaTable();
    try
    {
   
    foreach(DataRow myRow in schemaTable.Rows)
    {
    DataColumn myDataColumn = new DataColumn();
    myDataColumn.DataType = myRow.GetType();
    myDataColumn.ColumnName = myRow[0].ToString();
    datatable.Columns.Add(myDataColumn);
    }
    while(dataReader.Read())
    {
    DataRow myDataRow = datatable.NewRow();
    for(int i=0;i<schemaTable.Rows.Count;i++)
    {
    myDataRow[i] = dataReader[i].ToString();
    }
    datatable.Rows.Add(myDataRow);
    myDataRow = null;
    }
    schemaTable = null;
    return datatable;
    }
    catch(Exception ex)
    {
    Error.Log(ex.ToString());
    return datatable;
    }
   
    }
