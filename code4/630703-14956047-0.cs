    using System.Configuration;
    var connection = ConfigurationManager.ConnectionStrings["ComputerManagement"];
    if (connection != null) 
    {
        using (var sqlcon = new SqlConnection(connection.ConnectionString))
        {
            ...
        }
    }
