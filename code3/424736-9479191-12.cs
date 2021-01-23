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
    public static class DataReaderExtensions
    {  
        public static Int32 GetInt32(this IDataReader rdr, string fieldName)
        {
            int ordinal = rdr.GetOrdinal(fieldName);
            return !rdr.IsDBNull(ordinal) ? rdr.GetInt32(ordinal) : Int32.MinValue;
        }
    }
