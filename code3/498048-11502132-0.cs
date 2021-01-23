    public void Import()
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTrans = sqlConnection.BeginTransaction())
                    {
                        try
                        {                       
                            SqlCommand cmd = sqlConnection.CreateCommand();
                            cmd.CommandText = "select top 1 null from lockTable with(xlock)";
                            cmd.CommandTimeout = LOCK_TIME_OUT;
                            cmd.Transaction = sqlTrans;
                            SqlDataReader reader = cmd.ExecuteReader();
    
    
                            foreach (DataTable dt in DataTables)
                            {
                                ImportIntoDatabase(sqlConnection, dt, sqlTrans);                            
                            }
    
                            reader.Close();
                            sqlTrans.Commit();                        
                        }
                        catch (Exception ex)
                        {
                            sqlTrans.Rollback();
                            throw ex;
                        }
                    }
                    sqlConnection.Close();
                }
            }
