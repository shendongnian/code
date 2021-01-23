    internal class SqlCommandFactory
    {
        bool _useMyClass = true;
        public ISqlCommand CreateSqlCommand(string query)
        {
            if (_useMyClass)
            {
                return new MySqlCommand(query);
            }
            else
            {
                return new SqlCommandWrapper(query);
            }
        }
    }
