     public DataTable ExecuteParameterizedStoredProcedureObjects(string procedureName, Dictionary<string, object> parameters)
            {
                var dataTable = new DataTable();
                var _sqlConnection = new SqlConnection(_connectionString);
                var cmd = new SqlCommand(procedureName, _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
    
                var da = new SqlDataAdapter(cmd);
                foreach (var entry in parameters)
                {
                    cmd.Parameters.Add(entry.Key, entry.Value);
                }
    
                try
                {
                    _sqlConnection.Open();
                    da.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    var errorText = string.Format("Occ Repository ExecuteQuery Error : QueryString={0} :: Error={1}", procedureName, ex.Message);
                    throw new Exception(errorText, ex);
                }
                finally
                {
                    da.Dispose();
                    _sqlConnection.Dispose();
                }
    
                return dataTable;
            }
