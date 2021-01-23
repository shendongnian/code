        private void ReadFileFromDatabase()
        {
            byte[] fileData = null;
            string selectSql = "SELECT FILE_DATA FROM BLOBTEST WHERE FILE_ID=1";
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(selectSql, con);
            try
            {
                con.Open();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fileData = (byte[])reader["FILE_DATA"];
                        //do your operations with fileData here
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }
