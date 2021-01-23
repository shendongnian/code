    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    public class DataAccess
    {
        // This should be specific to your database.
        const string ConnectionString = 
            "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";
        const string TokenQuery @=
            "SELECT tokens FROM dbo.yt2016;"
      
        static IEnumerable<TToken> GetTokens<TToken>()
        {
            using (var connection = new SqlConnection(connectionString))
            {
            // Create the Command and Parameter objects.
            var command = new SqlCommand(TokenQuery, connection);
    
            // Create and execute the DataReader, 
            // casting and yielding to the caller.
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return (TToken)reader[0];
            }
            reader.Close();
        }
    }
