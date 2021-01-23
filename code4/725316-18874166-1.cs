    public class ProfileRouterHandler: IRouteHandler
    {
        private string VirtualPath { get; set; }
        public ProfileRouterHandler()
        {
           
        }
        
        public ProfileRouterHandler(string virtualPath)
        {
            VirtualPath = virtualPath;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string param = requestContext.RouteData.Values["uid"] as string;
            string mode = requestContext.RouteData.Values["mode"] as string;
            long id;
            long.TryParse(param, out id);
            if (id > 0)
            {
                string filePath = "~/Profile/Default.aspx?uid=" + param + (!string.IsNullOrEmpty(mode) ? "&mode=" + mode : "");
                VirtualPath = "~/Profile/Default.aspx";
                HttpContext.Current.RewritePath(filePath);
            }
            else
            {
                string filePath = "~/Profile/" + param + ".aspx";
                VirtualPath = filePath;
                HttpContext.Current.RewritePath(filePath);
            }
            return BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(Page)) as Page; 
        }
    }
