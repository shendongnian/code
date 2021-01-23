        public static IEnumerable<System.Data.IDataRecord> AsEnumerable(this System.Data.IDataReader reader)
        {
            while (reader.Read())
            {
                yield return reader;
            }
        }
