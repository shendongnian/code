    Int64 Id = 0;
    using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
    {
        //Goes through the List<object>
        conn.Open();
        foreach(List<object> sub in listSubject)
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "CALL stp_InsertSubject(@param_SubjectId, @param_ProjectId, @param_Used);";
            cmd.Parameters.AddWithValue("@param_SubjectId",Convert.ToInt32(sub[0]) );
            cmd.Parameters.AddWithValue("@param_ProjectId", Convert.ToInt32(sub[1]));
            cmd.Parameters.AddWithValue("@param_Used", Convert.ToBoolean(sub[2]) );
            Id = (Int64)cmd.ExecuteScalar();
        }
         conn.Close();
    }
