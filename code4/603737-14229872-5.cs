    internal class CommandFactory
    {
        bool _useMyClass = true;
        public ISqlCommand CreateSqlCommand(String query)
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
