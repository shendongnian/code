        private static DataSet dataset_test(string sql)
        {
            DataSet ds = new DataSet();
            using (OracleConnection objConn = new OracleConnection(connectionstring))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = sql;
                objCmd.CommandType = CommandType.Text;
                try
                {
                    objConn.Open();
                    OracleDataAdapter adapter = new OracleDataAdapter(objCmd);
                    adapter.ReturnProviderSpecificTypes = true;
                    adapter.Fill(ds);
                }
                catch (Exception)
                {
                    throw;
                }
                objConn.Close();
                return ds;
            }
        }
