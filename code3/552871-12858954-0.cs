    public static IEnumerable<string> Select(this DataReader reader, int index)
    {
        while (reader.Read())
        {
            yield return reader[index].ToString();
        }
    }
