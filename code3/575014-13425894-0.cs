    static IEnumerable<myReport> SelectReports(string myCommandText) {
    
        var connectionString = ConfigurationManager.ConnectionStrings["xxx"].ConnectionString;
        using(var conn = new SqlConnection(connectionString))
              return conn.Query<myReport>(myCommandText);    
    }
