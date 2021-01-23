    static public class SqliteExtensions
    {
        public static object ExecuteScalar(this SQLiteConnection connection, string commandText)
        {
            // Added using
            using (var command = connection.CreateCommand())
            {
                command.CommandText = commandText;
                return command.ExecuteScalar();
            }
        }
    }
