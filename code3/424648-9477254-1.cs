    string connectionString = ConfigurationManager.ConnectionStrings["MyConnStr"].ConnectionString;
    using(SqlConnection conn = new SqlConnection(connectionString))
    {
       ....
    }
