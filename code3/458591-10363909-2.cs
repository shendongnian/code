     using (var conn = new SqlConnection(SomeConnectionString))
     using (var cmd = conn.CreateCommand())
     {
       cmd.CommandText = "SELECT SpecID, Value2 FROM Specializationtbl WHERE SpecializationName= @Name";
       cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
       conn.Open();
       var dr = cmd.ExecuteReader();
       while (dr.Read())
       {
          Customer c = new Customer { 
                 ID = dr["SpecID"].ToString(),
                 Value = dr["Value2"].ToString(),
           };
       }
    }
