     using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"select column_name, table_name from information_schema.columns where table_name in ('tradeName',  'tableOne', 'tableTwo')"
                
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                  var a = reader[0];
                  Console.WriteLine(a);
                }
            }
