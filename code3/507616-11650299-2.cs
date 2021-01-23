    private static IEnumerable<int> Read(IDataReader reader)
    {
        IList<int> list = new List<int>();
        while (reader.Read())
        {
            list.Add(reader.GetInt32(0));
        }
        return list;
    }
