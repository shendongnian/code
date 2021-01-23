    using (SqlConnection conn = new SqlConnection(cs))
    {
       using (SqlCommand command = conn.CreateCommand())
       {
          conn.Open();
          string cmdText = String.Format("INSERT INTO UserFiles VALUES(@userRef, @name1, @name2, @name3, @name4, @name5, @name6)");
          command.Parameters.AddVithValue("@userRef", obj.userRef.ToString()); 
          command.Parameters.AddVithValue("@name1", name); 
          command.Parameters.AddVithValue("@name2", name); 
          command.Parameters.AddVithValue("@name3", name); 
          command.Parameters.AddVithValue("@name4", name); 
          command.Parameters.AddVithValue("@name5", name); 
          command.Parameters.AddVithValue("@name6", name); 
          command.CommandText = cmdText;
          command.ExecuteNonQuery();
          conn.Close();
       }
    }
