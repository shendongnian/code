    private static DataSet ExecuteQuery(IDataAdapter da)
    {
        DataSet ds = new DataSet("rawData");
        da.Fill(ds);
    
        ds.Tables[0].TableName = "row";
        foreach (DataColumn c in ds.Tables[0].Columns)
        {
            c.ColumnMapping = MappingType.Attribute;
        }
    
        return ds;
    }
