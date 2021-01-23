        private static List<List<Dictionary<string, object>>> ProcessReader(SqlCommand command)
        {
            var tables = new List<List<Dictionary<string, object>>>();
            using (var reader = command.ExecuteReader())
            {
                do
                {
                    var table = new List<Dictionary<string, object>>();
                    while (reader.Read())
                        table.Add(Read(reader));
                    tables.Add(table);
                } while (reader.NextResult());
            }
            return tables;
        }
