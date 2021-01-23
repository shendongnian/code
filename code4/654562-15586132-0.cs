    using (SqlConnection conn = new SqlConnection(cs))
    {
       using (SqlCommand command = conn.CreateCommand())
       {
          conn.Open();
          string cmdText = "INSERT INTO UserFiles VALUES('" + obj.userRef.ToString() + "','name','name','name','name','name','name')";
          command.CommandText = cmdText;
          command.ExecuteNonQuery();
       }
    }
