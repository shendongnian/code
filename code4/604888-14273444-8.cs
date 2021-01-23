    interface IStreamReader
    {
        string ReadLine();
        // etc...
    }
    public class StreamReaderWrapper : IStreamReader
    {
        private StreamReader _streamReader;
        public StreamReaderWrapper(string path)
        {
            _streamReader = new StreamReader(path);
        }
        public string ReadLine()
        {
            return _streamReader.ReadLine();
        }
    }
