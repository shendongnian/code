    class DBConnectivity : IDisposable // caveat! read below first
    {
        public void Dispose() {
            if(connection != null) { connection.Dispose(); connection = null; }
            if(command != null) { command.Dispose(); command = null; }
            if(dataReader != null) { dataReader.Dispose(); dataReader = null; }
        }
