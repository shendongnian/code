    IList<int> list = new List<int>();
    using (IDataRecord reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            list.Add(reader.GetInt32(0));
        }
    }
    int[] arr = list.ToArray();
