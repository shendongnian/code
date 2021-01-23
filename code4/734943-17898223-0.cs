    internal static class DataSource
    {
        private static string _ConnectionString;
        public static string ConnectionString
        {
            get
            {
                if (_ConnectionString == null)
                    _ConnectionString = FunctionToDynamicallyCreateConnectionstring();
                return _ConnectionString;
            }
        }
        private static string FunctionToDynamicallyCreateConnectionstring()
        {
             SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();
             // initialize cb's properties here...
             return cb.ToString();
        }
    }
