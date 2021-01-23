     using (SqlConnection conn = new SqlConnection(connstring))
        {           
            conn.Open();
            string commtext = @"Insert INTO table1 (Username)
                       SELECT @User";
            SqlCommand comm = new SqlCommand(commtext, conn);
            comm.Parameters.AddWithValue("@User", loggedinuser);
            identChange.ExecuteNonQuery();
            comm.ExecuteNonQuery();
            conn.Close();
        }
