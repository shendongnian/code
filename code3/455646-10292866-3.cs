    public void InsertSampleData(DataTable tempTable)
        {
           session.Transaction.Commit();
            var connection = session.SessionFactory.OpenSession().GetSessionImplementation().Connection;
            using (var sqlConnection = (SqlConnection)connection)
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
