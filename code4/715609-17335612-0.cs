    public class ReaderFailedEventArgs : EventArgs
    {
        public ReaderFailedEventArgs (IReader reader, Exception failure)
        {
        }
        // [.. Two read only properties here ..]
    }
    public class Worker
    {
        public event EventHandler<ReaderFailedEventArgs> ReaderFailed = delegate{};
        public IEnumerable<Data> Process()
        {
            foreach (var reader in _readers)
            {
                try
                {
                    return reader.Read();
                }
                catch (Exception ex)
                {
                    ReaderFailed(this, new ReaderFailedEventArgs(reader, ex);
                }
            }
            
            // now, this is a real exception since user expects to get data
            throw new InvalidOperationException("All readers failed");
        }
    }
