    static public class SqliteExtensions
    {
        public static object ExecuteScalar(this SQLiteConnection connection, string commandText)
        {
            object value = null;
            try
            {
                // Added using
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    value = command.ExecuteScalar();
                }
            }
            catch { }
            return value;
        }
    }
