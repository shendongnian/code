    var conString =System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringName"];
    string strConnString = conString.ConnectionString;
    SqlConnection con = new SqlConnection(strConnString);
    SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM Table;"), con);
    con.Open();
    SqlDataReader reader = cmd.ExecuteReader();
