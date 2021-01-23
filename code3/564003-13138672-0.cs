    SqlConnection questionConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    questionConnection.Open();
    DataSet ds = new DataSet();
    String sql = "SELECT * FROM HRA.dbo.Questions";
    SqlDataAdapter adapter = new SqlDataAdapter(sql, questionConnection);
    adapter.Fill(ds);
    
    adapter.Dispose();
    command.Dispose();
    questionConnection.Close();
