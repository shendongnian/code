    public class Resource: IDisposable
    {
        public void Close()
        {
            CleanupMemory();
        }
    
        private void CleanupMemory()
        {
            throw new Exception();
        }
    
        public void Dispose()
        {
            CleanupMemory();
        }
    }
