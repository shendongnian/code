    public class ExcelFileResult : IHasOptions, IStreamWriter
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
    
        public void WriteTo(Stream responseStream)
        {
            if (_responseStream == null) 
                return;
    
            _responseStream.WriteTo(responseStream);
            responseStream.Flush();
        }
    }
