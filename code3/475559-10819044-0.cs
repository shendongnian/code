    public static string Login(string passwort, string email, string firma)
    {
        string userName = "";
        using (SqlConnection con = new SqlConnection(@"Data Source=Yeah-PC\SQLEXPRESS;Initial Catalog=works;Integrated Security=true;"))
        using(SqlCommand cmd = new SqlCommand(@"SELECT firma FROM TestData WHERE email = @email", con))
        {
            cmd.Parameters.AddWithValue("@email", email);
            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    if (rdr["firma"]  != DBNull.Value)
                    {
                        userName += rdr["firma"].ToString();
                    }
                   
                }
            }
        }
           
        return userName;
    }
