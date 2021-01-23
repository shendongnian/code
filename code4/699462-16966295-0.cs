    public class LessHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;
            var user = context.User;
            string assetUrl = request.Url.LocalPath;
            string assetPath = context.Server.MapPath(assetUrl);
            //load less file into the data.
            var data = "";
            using (var file = new StreamReader(assetPath))
            {
                data = file.ReadToEnd();
            }
            DotlessConfiguration lessEngineConfig = DotlessConfiguration.GetDefault();
            lessEngineConfig.MapPathsToWeb = false;
            lessEngineConfig.CacheEnabled = false;
            lessEngineConfig.DisableUrlRewriting = false;
            lessEngineConfig.Web = false;
            lessEngineConfig.MinifyOutput = true;
            lessEngineConfig.LessSource = typeof(VirtualFileReader);
            var lessEngineFactory = new EngineFactory(lessEngineConfig);
            ILessEngine lessEngine = lessEngineFactory.GetEngine();
            string vars = "";
            //TODO set default for vars
            if (user != null)
            {
                //TODO get vars for user
            }
            var content = lessEngine.TransformToCss(string.Format("{0}{1}", vars, data), null);
            // Output text content of asset
            response.ContentType = "text/css";
            response.Write(content);
            response.End();
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
