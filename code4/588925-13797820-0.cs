            //TODO: set connection string
            string connString = "";
            string query = "select * from sysobjects where ytype='P' and name='MyStoredProcedureName'";
            bool spExists = false;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query,conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
	                    {
                            spExists = true;
                            break;
	                    }
                    }
                }
            }
