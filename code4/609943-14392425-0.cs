    public class RecirectionModule :IHttpModule{
        public void Init(HttpApplication context)
        {
            _context = context;
            context.BeginRequest += OnBeginRequest;
        }
    
        public void OnBeginRequest(object sender, EventArgs e)
        {
            string currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            string fileExtention = Path.GetExtension(currentUrl);
            string[] fileList= new[]{".jpg",".css",".gif",".png",".js"};
            if (fileList.Contains(fileExtention)) return;
                
            currentUrl = DoAnyTranformation(currentUrl);
            Redirect(currentUrl);
            
        }
        private void Redirect(string virtualPath)
        {
            if (string.IsNullOrEmpty(virtualPath)) return;
            _context.Context.Response.Status = "301 Moved Permanently";
            _context.Context.Response.StatusCode = 301;
            _context.Context.Response.AppendHeader("Location", virtualPath);
            _context.Context.Response.End();
        }
        public void Dispose()
        {
       
        }
    }
