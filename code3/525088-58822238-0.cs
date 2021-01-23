    public static class DbExtensions
    {
        public static void AddParameter(SQLiteCommand command, string name, DbType type, object value)
        {
            var param = new SQLiteParameter(name, type);
            param.Value = value;
            command.Parameters.Add(param);
        }
    }
