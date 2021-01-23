    public void ExampleCall(StorageFile storageFile)
    {
        IRandomAccessStreamWithContentType f = await storageFile.OpenReadAsync();
        var file = File.Create(new StreamFileAbstraction(storageFile.Name, f.AsStream()));
    }
    public class StreamFileAbstraction : File.IFileAbstraction
    {
        public StreamFileAbstraction(string name, Stream stream)
        {
            Name = name;
            ReadStream = stream;
            WriteStream = stream;
        }
        public void CloseStream(Stream stream)
        {
            stream.Flush();
        }
        public string Name { get; private set; }
        public Stream ReadStream { get; private set; }
        public Stream WriteStream { get; private set; }
    }
