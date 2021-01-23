            public void insertRowbyRowIntoTable(int ddlValue, string name)
        { 
            SqlConnection cnTemp = null;
            string spName = null;
            SqlCommand sqlCmdInsert = null;
            try
            {
                cnTemp = helper.GetConnection();
                using (SqlConnection connection = cnTemp)
                {
                    if (cnTemp.State != ConnectionState.Open)
                        cnTemp.Open();
                    using (sqlCmdInsert = new SqlCommand(spName, cnTemp))
                    {
                        spName = "dbo.usp_InsertRowsIntoOverview";
                        sqlCmdInsert = new SqlCommand(spName, cnTemp);
                        sqlCmdInsert.CommandType = CommandType.StoredProcedure;
                        sqlCmdInsert.Parameters.AddWithValue("@Year", ddlValue);
                        sqlCmdInsert.Parameters.AddWithValue("@TeamName", name);
                        sqlCmdInsert.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCmdInsert != null)
                    sqlCmdInsert.Dispose();
                if (cnTemp.State == ConnectionState.Open)
                    cnTemp.Close();
            }
        
        }
