    public IEnumerable<Company> GetCompanies()
    {
       using (var connection = new SqlConnection(connectionString))
       {
           connection.Open();
           return connection.Query<Company>("SELECT * FROM Companies");
       }
    }
