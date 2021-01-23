    class MyNpgSqlExceptionConverter : ISQLExceptionConverter
    {
        public Exception Convert(AdoExceptionContextInfo adoExceptionContextInfo)
        {
            var npgsqlException = (NpgsqlException)adoExceptionContextInfo.SqlException;
            switch (npgsqlException.Code)
            {
                case "<errorcode for duplicate key>":
                    return new WhateverException(...);
                    break;
                default:
                    break;
            }
        }
    }
