     try                                                             
            {
                OleDbConnection conn = GetConnection();
                OleDbCommand command = new OleDbCommand(queryString, conn);
                conn.Open();
                int count = (Int32) command.ExecuteScalar();
                conn.Close();    
            }
