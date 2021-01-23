    public static int login(SchoolBAL bal)
       {
           SqlConnection con = DBConnection.OpenConnection();
           try
           {
               int i;
               SqlCommand cmd1 = new SqlCommand("login", con);
                cmd1.CommandType = CommandType.StoredProcedure;
               cmd1.Parameters.AddWithValue("@username", bal.UserName);
               cmd1.Parameters.AddWithValue("@password", bal.Password);
               i = cmd1.executescaler();
               return i;              
    
           }
           catch (Exception)
           {
    
               throw;
           }
       }
