    class SomeClass : IDisposable
    {
        SqlConnection conn;
        public SomeClass
        {
            conn = new SqlConnection("some connectionstring");
        }
        public void Open()
        {
            conn.Open()
        }
        public void Close()
        {
            conn.Close()
        }
        public void Dispose()
        {
            conn.Dispose()
        }
    } 
