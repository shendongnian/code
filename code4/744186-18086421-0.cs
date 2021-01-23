    internal class Program
    {
        private static void Main(string[] args)
        {
            OdbcConnection connection = new OdbcConnection("");
            OdbcCommand command = new OdbcCommand("SELECT * FROM Table WHERE Id = @id AND Column = @text", connection);
            command.Parameters.Add("@id", OdbcType.Int).Value = 2;
            command.Parameters.Add("@text", OdbcType.VarChar).Value = "test";
            string preparedSql = command.GetPreparedSql();
            // preparedSql = SELECT * FROM Table WHERE Id = 2 AND Column = 'test'
            Console.ReadLine();
        }
    }
    public static class OdbcExtensions
    {
        public static string GetPreparedSql(this OdbcCommand command)
        {
            string commandText = command.CommandText;
            if (command.CommandType != CommandType.Text)
                return commandText;
            foreach (OdbcParameter parameter in command.Parameters)
            {
                string paramValue;
                switch (parameter.DbType)
                {
                    case DbType.Boolean:
                        paramValue = Convert.ToBoolean(parameter.Value) ? "1" : "0";
                        break;
                    case DbType.AnsiString:
                    case DbType.String:
                        paramValue = string.Format("'{0}'", parameter.Value);
                        break;
                    default:
                        paramValue = parameter.Value.ToString();
                        break;
                }
                commandText = commandText.Replace(parameter.ParameterName, paramValue);
            }
            return commandText;
        }
    }
