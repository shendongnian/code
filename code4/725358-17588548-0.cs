    private OdbcConnection ResolveConnection(OdbcConnectionStringBuilder connectionString)
    {
        if (!_connections.ContainsKey(connectionString.Dsn))
        {
            OdbcConnection connection = null;
                
            var newOdbcConnectionTimeout = TimeSpan.FromSeconds(30);
            var evt = new ManualResetEvent(false);
 
            var connectionThread = new Thread(() =>
                {
                    try
                    {
                        connection = new OdbcConnection(connectionString.ConnectionString);
                    }
                    finally
                    {
                        evt.Set();
                    }
                });
            connectionThread.Start();
            var isOk = evt.WaitOne(newOdbcConnectionTimeout);
 
            if (!isOk || connection == null)
            {
                connectionThread.Abort();
                const string messageFormat = "Timeout of {0} reached while creating OdbcConnection to {1}.";
                throw new InvalidOperationException(string.Format(messageFormat, newOdbcConnectionTimeout, connectionString));
            }
 
            _connections.Add(connectionString.Dsn, connection);
        }
 
        return _connections[connectionString.Dsn];
    }
