            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = connection.Query<CustomObject>(sql, commandType: CommandType.Text).ToList();
                return result;
            }
