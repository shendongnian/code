     public class FileLock : IDisposable
     {
        private FileStream _lock;
        public FileLock(string path)
        {
            if (File.Exists(path))
            {
                _lock = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                IsLocked = true;
            }            
        }
        public bool IsLocked { get; set; }
        public void Dispose()
        {
            if (_lock != null)
            {
                _lock.Dispose();
            }
        }
    }
