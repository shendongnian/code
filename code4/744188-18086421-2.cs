    internal class Program
    {
        private static void Main(string[] args)
        {
            OdbcConnection connection = new OdbcConnection("");
            OdbcCommand command = new OdbcCommand("SELECT * FROM Table WHERE Id = ? AND Column = ?", connection);
            command.Parameters.Add("@id", OdbcType.Int).Value = 2;
            command.Parameters.Add("@text", OdbcType.VarChar).Value = "test";
            string preparedSql = command.GetPreparedSql();
            // preparedSql = 
            Console.ReadLine();
        }
    }
    public static class OdbcExtensions
    {
        public static string GetPreparedSql(this OdbcCommand command)
        {
            string[] splitted = command.CommandText.Split(new[] {'?'}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < splitted.Length; i++)
            {
                builder.Append(splitted[i]);
                OdbcParameter param = command.Parameters[i];
                switch (param.DbType)
                {
                    case DbType.Boolean:
                        builder.Append(Convert.ToBoolean(param.Value) ? "1" : "0");
                        break;
                    case DbType.AnsiString:
                        builder.AppendFormat("'{0}'", param.Value);
                        break;
                    default:
                        builder.Append(param.Value);
                        break;
                }
                builder.Append(" ");
            }
            return builder.ToString();
        }
    }
