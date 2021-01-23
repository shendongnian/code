    using System.Data.SqlClient;
    SqlConnection connection = new SqlConnection("<connection string>");
    connection.Open();
    SqlCommand command = new SqlCommand(myquery, connection)
    command.ExecuteNonQuery();
