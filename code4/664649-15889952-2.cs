    class Program
    {
        static void Main(string[] args)
        {
            var appHost = new AppHost();
            appHost.Init();
            appHost.Start("http://*:1337/");
            System.Console.WriteLine("Listening on http://localhost:1337/ ...");
            System.Console.ReadLine();
			System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
		}
    }
    [Route("/Hello/{Name}")]
    public class Hello
    {
        public string Name { get; set; }
    }
    public class HelloService : Service
    {
        public string Any(Hello request)
        {
            return request.Name;
        }
    }
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("Test Console", typeof(AppHost).Assembly) { }
        public override void Configure(Funq.Container container)
        {
            CatchAllHandlers.Add(StaticFileHandler.Factory);
        }
    }
    public class StaticFileHandler : EndpointHandlerBase
    {
        protected static readonly Dictionary<string, string> ExtensionContentType;
        protected FileInfo fi;
        static StaticFileHandler()
        {
            ExtensionContentType = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) 
        {
            { ".text", "text/plain" },
            { ".js", "text/javascript" },
            { ".css", "text/css" },
            { ".html", "text/html" },
            { ".htm", "text/html" },
            { ".png", "image/png" },
            { ".ico", "image/x-icon" },
            { ".gif", "image/gif" },
            { ".bmp", "image/bmp" },
            { ".jpg", "image/jpeg" }
        };
        }
        public string BaseDirectory { protected set; get; }
        public string Prefix { protected set; get; }
        public StaticFileHandler(string baseDirectory, string prefix)
        {
            BaseDirectory = baseDirectory;
            Prefix = prefix;
        }
        private StaticFileHandler(FileInfo fi)
        {
            this.fi = fi;
        }
        public static StaticFileHandler Factory(string baseDirectory, string prefix, string pathInfo)
        {
            return new StaticFileHandler(new FileInfo(@"C:\Test.xml"));
        }
        public override void ProcessRequest(IHttpRequest httpReq, IHttpResponse httpRes, string operationName)
        {
            var bytes = File.ReadAllBytes(fi.FullName);
            httpRes.AddHeader("Date", DateTime.Now.ToString("R"));
            httpRes.AddHeader("Content-Type", "text/plain");
            httpRes.AddHeader("Test", "SetThis");
            httpRes.OutputStream.Write(bytes, 0, bytes.Length);
        }
        public override object CreateRequest(IHttpRequest request, string operationName)
        {
            return null;
        }
        public override object GetResponse(IHttpRequest httpReq, IHttpResponse httpRes, object request)
        {
            return null;
        }
    }
