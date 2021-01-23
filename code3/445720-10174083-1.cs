            string query = @"UPDATE session SET logout_time = @LogOutTime 
                                    WHERE user_id = @UId AND PK_Id = @SessionId";
            try
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@UId", Utility.usr.Id);
                cmd.Parameters.AddWithValue("@SessionId", s.ToByteArray());
                cmd.Parameters.AddWithValue("@LogOutTime", DateTime.Now);
                cmd.ExecuteNonQuery();
