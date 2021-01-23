    public class SomeRepository 
            {
                private  string _connectionString { get; set; }
                private  SqlConnection _sqlConnection { get; set; }
        
                public SomeRepository()
                {
                    switch (AppSettings.ReleaseMode)
                    {
                        case ReleaseMode.DEV:
                            _connectionString = "server=;database=;User Id=;Password=";
                            break;
                        case ReleaseMode.PRODUCTION:
                            _connectionString = "server=;database=;User Id=;Password=";
                            break;
                    }            
                }     
        
                public  DataTable ExecuteQuery(string commandText)
                {
                    var dataTable = new DataTable();
                    var _sqlConnection = new SqlConnection(_connectionString);
                    var cmd = new SqlCommand(commandText, _sqlConnection);
                    var da = new SqlDataAdapter(cmd);
        
                    try
                    {              
                        _sqlConnection.Open();
                        da.Fill(dataTable);                             
                    }
                    catch (Exception ex)
                    {
                        var errorText = string.Format("Occ Repository ExecuteQuery Error : QueryString={0} :: Error={1}", commandText, ex.Message);
                        throw new Exception(errorText, ex);
                    }
                    finally
                    {                
                        da.Dispose();
                        _sqlConnection.Dispose();
                    }
        
                    return dataTable;
                }
        
                public DataTable ExecuteParameterizedQuery(string commandText, Dictionary<string, string> parameters)
                {
                    var dataTable = new DataTable();
                    var _sqlConnection = new SqlConnection(_connectionString);
                    var cmd = new SqlCommand(commandText, _sqlConnection);
                  
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
                        var errorText = string.Format("Occ Repository ExecuteQuery Error : QueryString={0} :: Error={1}", commandText, ex.Message);
                        throw new Exception(errorText, ex);
                    }
                    finally
                    {
                        da.Dispose();
                        _sqlConnection.Dispose();
                    }
        
                    return dataTable;
                }
        
                public DataTable ExecuteParameterizedQueryObjects(string commandText, Dictionary<string, object> parameters)
                {
                    var dataTable = new DataTable();
                    var _sqlConnection = new SqlConnection(_connectionString);
                    var cmd = new SqlCommand(commandText, _sqlConnection);
        
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
                        var errorText = string.Format("Occ Repository ExecuteQuery Error : QueryString={0} :: Error={1}", commandText, ex.Message);
                        throw new Exception(errorText, ex);
                    }
                    finally
                    {
                        da.Dispose();
                        _sqlConnection.Dispose();
                    }
        
                    return dataTable;
                }
        
                public int ExecuteNonQuery(string commandText)
                {          
                    var _sqlConnection = new SqlConnection(_connectionString);
                    var rowsAffected = 0;
        
                    try
                    {              
                        var cmd = new SqlCommand(commandText, _sqlConnection);
                        _sqlConnection.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var errorText = string.Format("Occ Repository ExecuteNonQuery Error : Command={0} :: Error={1}", commandText, ex.Message);
                        throw new Exception(errorText, ex);
                    }
                    finally
                    {
                        _sqlConnection.Dispose();
                    }
        
                    return rowsAffected;
                }
        
                public int ExecuteParameterizedNonQuery(string commandText, Dictionary<string, string> parameters)
                {
                    var _sqlConnection = new SqlConnection(_connectionString);
                    var rowsAffected = 0;
                    var cmd = new SqlCommand(commandText, _sqlConnection);
        
                    foreach (var entry in parameters)
                    {
                        cmd.Parameters.Add(entry.Key, entry.Value);
                    }
        
                    try
                    {               
                        _sqlConnection.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var errorText = string.Format("Occ Repository ExecuteNonQuery Error : Command={0} :: Error={1}", commandText, ex.Message);
                        throw new Exception(errorText, ex);
                    }
                    finally
                    {
                        _sqlConnection.Dispose();
                    }
        
                    return rowsAffected;
                }
        
                public int ExecuteParameterizedNonQueryObjects(string commandText, Dictionary<string, object> parameters)
                {
                    var _sqlConnection = new SqlConnection(_connectionString);
                    var rowsAffected = 0;
                    var cmd = new SqlCommand(commandText, _sqlConnection);
        
                    foreach (var entry in parameters)
                    {
                        cmd.Parameters.Add(entry.Key, entry.Value);
                    }
        
                    try
                    {
                        _sqlConnection.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var errorText = string.Format("Occ Repository ExecuteNonQuery Error : Command={0} :: Error={1}", commandText, ex.Message);
                        throw new Exception(errorText, ex);
                    }
                    finally
                    {
                        _sqlConnection.Dispose();
                    }
        
                    return rowsAffected;
                }
              
            }
