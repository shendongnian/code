    public class SqlServerExceptionConverter : ISQLExceptionConverter
    {
        public Exception Convert(AdoExceptionContextInfo adoExceptionContextInfo)
        {
            var sqlException = adoExceptionContextInfo.SqlException as SqlException;
            if (sqlException != null)
            {
                // 2601 is unique key, 2627 is unique index; same thing: 
                // http://blog.sqlauthority.com/2007/04/26/sql-server-difference-between-unique-index-vs-unique-constraint/
                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    return new UniqueKeyException(sqlException.Message, sqlException);
                }
            }
            return adoExceptionContextInfo.SqlException;
        }
    }
    public class UniqueKeyException : Exception
    {
        public UniqueKeyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
