    public DataTable GetUserAssociatedModules(string userEmail)
    {
    var dt = new DataTable();
    string connString = AppConfigurationManager.GetAppSetting("ConnectionString",IsTest,IsQA, IsProd);
    using (var conn = new SqlConnection(connString))
    {
        conn.Open();
        using (var sqlCommand = new SqlCommand("GetUserAssociatedModules", conn))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userEmail", userEmail);
                    
            SqlDataReader dr = null;
            DataSet ds = new DataSet();
            try
            {
                dr = sqlCommand.ExecuteReader();
                dt = new DataTable("DatatTable_GetUserAssociatedModules");
                ds.Tables.Add(dt);
                ds.Load(dr, LoadOption.OverwriteChanges, dt);
            }
            catch (SqlException ex)
            {
                LogExceptions(ex, new List<Param> { new Param { Name = "userEmail", Value = userEmail} });
             }
            catch (Exception ex)
            {
                LogExceptions(ex, new List<Param> { new Param { Name = "userEmail", Value = userEmail} });
            }
            finally
            {
    
            }
        }
    }
    return dt;
    }
