    private static IEnumerable<object[]> Read(DbDataReader reader)
    {
        while (reader.Read())
        {
            var values = new List<object>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                values.Add(reader.GetValue(i));
            }
            yield return values.ToArray();
        }
    }
