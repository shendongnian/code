    public static class DataHelper
    {
        public IDataReader ExecuteQuery(IDbConnection conn, String sql)
        {
           Sqm.TimerStart("DataHelper_ExecuteQuery");
           ...
           Sqm.TimerStop("DataHelper_ExecuteQuery");
        }
    }
