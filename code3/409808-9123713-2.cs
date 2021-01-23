    namespace SampleApp
    {
        public class LocalizationModule : IHttpModule
        {
            private HashSet<string> _supportedCultures =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "de", "es", "fr" };
            private string _appPath = HttpRuntime.AppDomainAppVirtualPath;
            public void Dispose()
            {
            }
            public void Init(HttpApplication application)
            {
                application.BeginRequest += this.BeginRequest;
                _appPath = HttpRuntime.AppDomainAppVirtualPath;
                if (!_appPath.EndsWith("/"))
                    _appPath += "/";
            }
            private void BeginRequest(object sender, EventArgs e)
            {
                HttpContext context = ((HttpApplication)sender).Context;
                string path = context.Request.Path;
                string cultureName = this.GetCultureFromPath(ref path);
                if (cultureName != null)
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureName);
                    context.RewritePath(path);
                }
            }
            private string GetCultureFromPath(ref string path)
            {
                if (path.StartsWith(_appPath, StringComparison.OrdinalIgnoreCase))
                {
                    int startIndex = _appPath.Length;
                    int index = path.IndexOf('/', startIndex);
                    if (index > startIndex)
                    {
                        string cultureName = path.Substring(startIndex, index - startIndex);
                        if (_supportedCultures.Contains(cultureName))
                        {
                            path = _appPath + path.Substring(index + 1);
                            return cultureName;
                        }
                    }
                }
                return null;
            }
        }
    }
