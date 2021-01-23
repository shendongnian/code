    public class CustomRazorViewEngine : RazorViewEngine
    {
        public CustomRazorViewEngine()
        {
            ViewLocationFormats = new string[] { "~/Views/%1/{1}/{0}.cshtml"};
            MasterLocationFormats = new string[] { "~/Views/%1/{1}/{0}.cshtml",
                           "~/Views/Shared/%1/{0}.cshtml"};
            PartialViewLocationFormats = new string[] { "~/Views/Rooms/{1}/{0}.cshtml",
                            "~/Views/Shared/%1/{0}.cshtml"};
            FileExtensions = new string[] { "cshtml"};
        }
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var path = GetPath(controllerContext.Controller.GetType().Namespace);
            return base.CreatePartialView(controllerContext, partialPath.Replace("%1", path));
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var path = GetPath(controllerContext.Controller.GetType().Namespace);
            return base.CreateView(controllerContext, viewPath.Replace("%1", path), masterPath.Replace("%1", path));
        }
        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            var path = GetPath(controllerContext.Controller.GetType().Namespace);
            return base.FileExists(controllerContext, virtualPath.Replace("%1", path));
        }
        private string GetPath(string nameSpace)
        {
            var split = nameSpace.Split('.');
            int startingIndex = 0;
            StringBuilder sb = new StringBuilder();
            foreach(string s in split)
            {
                startingIndex++;
                if (s == "Controllers")
                {
                    break;
                }
            }
            for(int x = startingIndex; x < split.Length; x++)
            {
                sb.Append(split[x]);
                if (x != split.Length - 1)
                {
                    sb.Append("/");
                }
            }
            return sb.ToString();
        }
