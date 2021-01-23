    public static readonly string ConnectionString connString =
        ConfigurationManager.ConnectionStrings["SQL"].ConnectionString.ToString();
...
    private void SomeMethod()
    {
        using (var conn = new SqlConnection(connString)) {
            string sql = "SELECT ...";
            using (var cmd = new SqlCommand(sql, conn)) {
                ...
            }
        }
    }
