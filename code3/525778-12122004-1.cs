    public static DataSet getGraphData(Int32 type)
    {
        SqlConnection oConn = null;
        DataSet dsReturn = null;
        try
        {
            getConnection(ref oConn, 1);
    
            using (SqlStoredProcedure sspObj = new SqlStoredProcedure("dbo.usp_getGraphData", oConn, CommandType.StoredProcedure))
            {
                sspObj.AddParameterWithValue("@Type", SqlDbType.Int, 0, ParameterDirection.Input, type);
                dsReturn = sspObj.ExecuteDataSet();
                //You don't need Dispose() - because the using will do that on sspObj
            }
            closeConnection(ref oConn);
        }
        catch (Exception xObj)
        {
            dsReturn = new DataSet("Empty");
        }
        return dsReturn ;
    }
