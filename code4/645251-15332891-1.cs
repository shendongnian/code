    public static int login(string userlogin, string pwdlogin)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = GetConnectionString();
        con.Open();
        int id = 0;
        string selectstr = "SELECT UserId FROM Registration WHERE UserName = '" +    userlogin.Trim() + "' AND Password = '" + pwdlogin.Trim() + "'";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = selectstr;
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = con;
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        id = reader.GetInt32("UserId");
        reader.Close();
        con.Close();
 
        return id;
    }
