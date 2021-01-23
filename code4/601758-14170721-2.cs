    SqlConnection connection = new SqlConnection(DataManager.DBConnectString);
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert_AddSomething";
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userid;
    
                    connection.Open();
                    cmd.ExecuteNonQuery();
    
                    }
