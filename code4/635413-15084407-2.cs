    class Manager : IDisposable
    {
        ...
        public void Dispose()
        {
            if(connection != null) connection.Dispose();
            connection = null;
        }
    }
