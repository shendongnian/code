    using System.Configuration;
    using System.Data.SqlClient;
    var connection = ConfigurationManager.ConnectionStrings["ComputerManagement"];
    if (connection != null) 
    {
        using (var sqlcon = new SqlConnection(connection.ConnectionString))
        {
            ...
        }
    }
