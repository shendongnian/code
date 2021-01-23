            DataTable dtTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection("Your connection"))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("Select Item FROM Calendar Where UserD='Test'", sqlConnection))
                    {
                        sqlConnection.Open();
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            dtTable.Load(sqlDataReader);
                            sqlDataReader.Close();
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
            ddlList.DataSource = dtTable;
            ddlList.DataBind();
