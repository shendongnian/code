            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                IList<CustomObject> result = connection.Query<CustomObject>(sql, commandType: CommandType.Text).ToList();
            }
