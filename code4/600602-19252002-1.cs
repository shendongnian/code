    public class StreamedResult : IHasOptions, IStreamWriter
    {
        public IDictionary<string, string> Options { get; private set; }
        Stream _responseStream;
        public StreamedResult(Stream responseStream)
        {
            _responseStream = responseStream;
            long length = -1;
            try { length = _responseStream.Length; }
            catch (NotSupportedException) { }
            Options = new Dictionary<string, string>
            {
                {"Content-Type", "application/octet-stream"},
                { "X-Api-Length", length.ToString() }
            };
        }
        public void WriteTo(Stream responseStream)
        {
            if (_responseStream == null)
                return;
            using (_responseStream)
            {
                _responseStream.WriteTo(responseStream);
                responseStream.Flush();
            }
        }
    }
