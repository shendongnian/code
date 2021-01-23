    public void InsertSampleData(DataTable tempTable)
    {
        session.Transaction.Commit();
        
        using (var sqlConnection = new SqlConnection(session.GetSessionImplementation()
                                           .Connection.ConnectionString))
        {
            using (var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.insertData";
                cmd.Parameters.Add("@sItems", SqlDbType.Structured);
                var sqlParam = cmd.Parameters["@Items"];
                sqlParam.Direction = ParameterDirection.Input;
                sqlParam.TypeName = "[dbo].[DataItemType]";
                sqlParam.Value = tempTable;
                cmd.ExecuteNonQuery();
            }
        }
    }
