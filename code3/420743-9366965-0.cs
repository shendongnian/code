    public static IEnumerable<IDataRecord> AsEnumerable(this IDataReader reader)
    {
        while (reader.Read())
        {
            yield return reader;
        }
    }
    ...
    using (var reader = SqlHelper.ExecuteReader(connectionString, query))
    {
        var list = reader.AsEnumerable().Select(r => r.GetString(0)).ToList();
    }
