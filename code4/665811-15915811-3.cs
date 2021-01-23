    public static class DataReaderExtensions
    {
        public static IList<IDictionary<string, object>> ListRecordsAsDictionaries(this IDataReader reader)
        {
            var list = new List<IDictionary<string, object>>();
            while (reader.Read())
            {
                var record = new Dictionary<string, object>();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var key = reader.GetName(i);
                    var value = reader[i];
                    record.Add(key, value);
                }
                list.Add(record);
            }
            return list;
        }
    }
