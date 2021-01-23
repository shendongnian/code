    SqlConnection con = new SqlConnection();
    con.ConnectionString = ConfigurationManager.ConnectionStrings["yourconnectionstringnamehere"].ConnectionString;
    con.Open();
    SqlCommand com = new SqlCommand();
    com.Connection = con;
    com.CommandText = "DELETE FROM [tablenamehere]";
    SqlDataReader data = com.ExecuteReader();
    con.Close();
