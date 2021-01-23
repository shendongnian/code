    public class UploadController : ApiController
    {
        private static ConcurrentDictionary<string, State> _state = new ConcurrentDictionary<string, State>();
    
        public State Get(string id)
        {
            State state;
    
            if (_state.TryGetValue(id, out state))
            {
                return state;
            }
    
            return null;
        }
    
    
        public async Task<HttpResponseMessage> Post([FromUri] string id)
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                var state = new State(Request.Content.Headers.ContentLength);
                if (!_state.TryAdd(id, state))
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Conflict));
    
                var path = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data");
    
                var provider = new FileMultipartStreamProvider(path, state.Start, state.AddBytes);
    
                await Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
                {
                    _state.TryRemove(id, out state);
    
                    if (t.IsFaulted || t.IsCanceled)
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                });
    
    
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }
    }
    
    
    public class State
    {
        public long? Total { get; set; }
    
        public long Received { get; set; }
    
        public string Name { get; set; }
    
        public State(long? total = null)
        {
            Total = total;
        }
    
        public void Start(string name)
        {
            Received = 0;
            Name = name;
        }
    
        public void AddBytes(long size)
        {
            Received = size;
        }
    }
    
    public class FileMultipartStreamProvider : MultipartStreamProvider
    {
        private string _rootPath;
        private Action<string> _startUpload;
        private Action<long> _uploadProgress;
    
        public FileMultipartStreamProvider(string root_path, Action<string> start_upload, Action<long> upload_progress)
            : base()
        {
            _rootPath = root_path;
            _startUpload = start_upload;
            _uploadProgress = upload_progress;
        }
    
        public override System.IO.Stream GetStream(HttpContent parent, System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = (headers.ContentDisposition.Name ?? "undefined").Replace("\"", "").Replace("\\", "_").Replace("/", "_").Replace("..", "_");
    
            _startUpload(name);
    
            return new WriteFileStreamProxy(Path.Combine(_rootPath, name), _uploadProgress);
        }
    
    }
    
    public class WriteFileStreamProxy : FileStream
    {
        private Action<long> _writeBytes;
    
        public WriteFileStreamProxy(string file_path, Action<long> write_bytes)
            : base(file_path, FileMode.Create, FileAccess.Write)
        {
            _writeBytes = write_bytes;
        }
    
        public override void EndWrite(IAsyncResult asyncResult)
        {
            base.EndWrite(asyncResult);
    
    #if DEBUG
            System.Threading.Thread.Sleep(100);
    #endif
    
            if (_writeBytes != null)
                _writeBytes(base.Position);
    
        }
    
        public override void Write(byte[] array, int offset, int count)
        {
            base.Write(array, offset, count);
    
    #if DEBUG
            System.Threading.Thread.Sleep(100);
    #endif
            if (_writeBytes != null)
                _writeBytes(base.Position);
        }
    }
