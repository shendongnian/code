    public static bool login(SchoolBAL bal)
    {
      bool isFound=false;
      using(SqlConnection con = DBConnection.OpenConnection())
       {
        using(SqlCommand cmd1 = new SqlCommand("login", con))
        {
         cmd1.CommandType = CommandType.StoredProcedure;
         cmd1.Parameters.AddWithValue("@username", bal.UserName);
         cmd1.Parameters.AddWithValue("@password", bal.Password);
         con.Open(); 
         SqlDataReader dr = cmd1.ExecuteReader();
         if(dr.Read())
           isFound=true;
         dr.Close();
         con.Close();
         }
        }
      return isFound;
    }
 
