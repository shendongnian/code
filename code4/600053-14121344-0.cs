        _logger.Info("DeleteTempTable");
        try
        {
            using(SqlConnection oConnDropTables = new SqlConnection(connectionString))
            {
                oConnDropTables.Open();
                foreach (KeyValuePair<string, string> item in _stables)
                {                 
                    string dropSql = string.Empty;
                    dropSql = string.Format("DROP TABLE [{0}];", item.Value);                 
                    if (!string.IsNullOrEmpty(dropSql))
                    {
                        using (SqlCommand cmd = new SqlCommand(dropSql, oConnDropTables))
                        {                              
                            cmd.ExecuteNonQuery();                             
                        }
                    }
                }
                if (oConnDropTables != null && oConnDropTables.State == ConnectionState.Open)
                oConnDropTables.Close();                    
            }
        }
        catch (Exception ex)
        {
            _logger.Error("Error " + ex.Message);
            throw ex;
        }
    }
