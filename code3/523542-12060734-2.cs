    public class ExcelFileResult : IHasOptions, IStreamWriterAsync
    {
        private readonly Stream _responseStream;
        public IDictionary<string, string> Options { get; private set; }
    
        public ExcelFileResult(Stream responseStream)
        {
            _responseStream = responseStream;
    
            Options = new Dictionary<string, string> {
                 {"Content-Type", "application/octet-stream"},
                 {"Content-Disposition", ""attachment; filename=\"report.xls\";"}
             };
        }
    
        public async Task WriteToAsync(Stream responseStream, CancellationToken token = default)
        {
            if (_responseStream == null) 
                return;
    
            await _responseStream.CopyToAsync(responseStream, token);
            await responseStream.FlushAsync(token);
        }
    }
