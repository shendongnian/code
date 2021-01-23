    using (SqlCommand cmd = new SqlCommand("INSERT INTO TableFFF (Word, Frequency) VALUES (@word, @freq)", con))
    {
        con.Open();
        for (int i = 0; i < dict.Count; i++)
       {   
          cmd.Parameters.Add(new SqlParameter("@word", pair[i].Key);
          cmd.Parameters.Add(new SqlParameter("@freq", pair[i].Value);
    
          cmd.ExecuteNonQuery();
        
        }
    }
