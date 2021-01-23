    public SqlDataReader  Login_Validation(string email, string password)
    {
       SqlConnection con = new     SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        LocalConnection_Class(con);
        SqlCommand cmd = new SqlCommand("Login_Validation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 100)).Value = email;
        cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50)).Value = password;
        SqlDataReader dr = cmd.ExecuteReader(); 
        cmd.Dispose();
        con.Close();
        return dr ;
    }
