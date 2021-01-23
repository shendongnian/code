        public bool IsServerConnected()
        {
            using (var l_oConnection = new SqlConnection(DBConnection.ConnectionString))
            {
                try
                {
                    l_oConnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
