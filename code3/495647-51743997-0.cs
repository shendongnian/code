    public DataSet GetDataSet()
        {
            try
            {
                DataSet dsReturn = new DataSet();
                using (SqlConnection myConnection = new SqlConnection(Core.con))
                {
                    string query = "select * from table1;  select* from table2";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dsReturn.Load(reader, LoadOption.PreserveChanges, new string[] { "tableOne", "tableTwo" });
                    return dsReturn;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
