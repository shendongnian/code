    public static class DataReaderExtension
        {
            public static IEnumerable<Object[]> DataRecord(this System.Data.IDataReader source)
            {
                if (source == null)
                    throw new ArgumentNullException("source");
    
                while (source.Read())
                {
                    Object[] row = new Object[source.FieldCount];
                    source.GetValues(row);
                    yield return row;
                }
            }
        }
