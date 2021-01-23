    public static void PerformDBWriteTransaction(string inputSQLStatement)
    {
        DataTable returnDataTable = new DataTable();
        try
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlTransaction sqlTrans = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(inputSQLStatement, sqlConnection))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = sqlTrans;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        sqlTrans.Rollback();
    
                        throw sqlEx;
                    }
                    sqlTrans.Commit();
                }
            }
        }
        catch (Exception ex)
        {
            errorMessages.Clear();
            errorMessages.Append("The following errors were found in the SQL statement:\n\n");
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                errorMessages.Append("Index #" + i + "\n" +
                "Message: " + ex.Errors[i].Message + "\n" +
                "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                "Source: " + ex.Errors[i].Source + "\n" +
                "Procedure: " + ex.Errors[i].Procedure + "\n");
            }
            MessageBox.Show(errorMessages.ToString());
        }
    }
