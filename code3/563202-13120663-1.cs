    public class MyObject : IDisposable
    {
        private SqlConnection _sqlConn;
        public MyObject()
        {
            _sqlConn = new SqlConnection("connection string");
            _sqlConn.Open();
        }
        void IDisposable.Dispose()
        {
            if (_sqlConn != null)
            {
                if (_sqlConn.ConnectionState == ConnectionState.Open)
                {
                    _sqlConn.Close();
                }
                _sqlConn.Dispose();
                _sqlConn = null;
            }
            // tell the garbage collector to ignore this object as you've tidied it up yourself
            GC.SuppressFinalize(this);
        }
    }
