    using(SqlConnection sqlConnection=new SqlConnection(connectionString))
    {
         string insertStatement="INSERT INTO TableName(column1,column2) VALUES (@col1, @col2)";
         SqlCommand sqlCommand=new SqlCommand(insertStatement,sqlConnection);
         sqlCommand.Parameters.AddWithValue("@col1", Text1);
         sqlCommand.Parameters.AddWithValue("@col2", Text2);
         sqlConnection.Open();
         sqlCommand.ExecuteNonQuery();
    }
