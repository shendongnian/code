    public interface IDirectoryEntry : IDisposable
    {
        IDictionary Properties { get; }
    }
    public class DirectoryEntryWrapper : IDirectoryEntry
    {
        private readonly DirectoryEntry _entry;
        public DirectoryEntryWrapper(DirectoryEntry entry)
        {
            _entry = entry;
            Properties = _entry.Properties;
        }
        public void Dispose()
        {
            if (_entry != null)
            {
                _entry.Dispose();
            }
        }
        public IDictionary Properties { get; private set; }
    }
