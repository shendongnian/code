    public static SqlConnection dbconnection()
    {
       string strcon = @"Data Source=local\SQLEXPRESS;Initial Catalog=aniv;Integrated Security=True";
       SqlConnection con = new SqlConnection(strcon);
       con.Open();
       return con;
    }
