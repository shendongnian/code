    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
         conn.Open();
    SqlCommand cmd = new SqlCommand("select*from raj where firstname like  @firstname", conn);
         cmd.Parameters.AddWithValue("@firstname","%"+prefixText+"%");        
         List<string> firstname = new List<string>();
         using (SqlDataReader reader = cmd.ExecuteReader())
         {
             while (reader.Read())
             {
                firstname.Add(reader[0].ToString());
             }             
             reader.Close();
         }
         connection.Close(); 
         return firstname; 
