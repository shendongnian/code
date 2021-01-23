    class SchemaWriter : IDisposable
    {
        private StreamWriter sw;
        public void Dispose()
        {
           sw.Dispose();
        }
    
        ...
    }
