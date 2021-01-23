        var listID= new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        using (var sqlConnection = new SqlConnection(_connectionstring))
        {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = sqlConnection;
                cmd.CommandText = "delete from MyTable where TableID in (" + String.Join(",",listID) + ")";
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }
