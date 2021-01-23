    public class FileDownload
    {
        private volatile bool _allowedToRun;
        private string _source;
        private string _destination;
        private int _chunkSize;
    
        private Lazy<int> _contentLength;
    
        public int BytesWritten { get; private set; }
        public int ContentLength { get { return _contentLength.Value; } }
    
        public bool Done { get { return ContentLength == BytesWritten; } }
    
        public FileDownload(string source, string destination, int chunkSize)
        {
            _allowedToRun = true;
    
            _source = source;
            _destination = destination;
            _chunkSize = chunkSize;
            _contentLength = new Lazy<int>(() => Convert.ToInt32(GetContentLength()));
    
            BytesWritten = 0;
        }
    
        private long GetContentLength()
        {
            var request = (HttpWebRequest)WebRequest.Create(_source);
            request.Method = "HEAD";
    
            using (var response = request.GetResponse())
                return response.ContentLength;
        }
    
        private async Task Start(int range)
        {
            if (!_allowedToRun)
                throw new InvalidOperationException();
    
            var request = (HttpWebRequest)WebRequest.Create(_source);
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            request.AddRange(range);
    
            using (var response = await request.GetResponseAsync())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var fs = new FileStream(_destination, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                        while (_allowedToRun)
                        {
                            var buffer = new byte[_chunkSize];
                            var bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length);
    
                            if (bytesRead == 0) break;
    
                            await fs.WriteAsync(buffer, 0, bytesRead);
                            BytesWritten += bytesRead;
                        }
    
                        await fs.FlushAsync();
                    }
                }
            }
        }
    
        public Task Start()
        {
            _allowedToRun = true;
            return Start(BytesWritten);
        }
    
        public void Pause()
        {
            _allowedToRun = false;
        }
    }
