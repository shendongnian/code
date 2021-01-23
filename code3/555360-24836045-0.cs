        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                if (_dbConnection != null)
                {
                    _dbConnection.Cancel();
                    _dbConnection.Close();
                    _dbConnection.Dispose();
                }
            }
            _disposed = true;
        }
