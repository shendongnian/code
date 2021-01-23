    public static class SqlDataReaderExtensions
    {
        public static T Field<T>(this SqlDataReader reader, string columnName)
        {
            object obj = reader[columnName];
            if (obj == null)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        "reader does not contain column: {0}",
                        columnName
                    )
                );
            }
            if (obj is DBNull)
            {
                obj = null;
            }
            return (T)obj;
        }
    }
