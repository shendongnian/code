    namespace SampleApp
    {
        public class LocalizationModule : IHttpModule
        {
            private HashSet<string> _supportedCultures = new HashSet<string> { "de", "es", "fr" };
            private Regex _pathRegex = new Regex("^/([a-z]+)(/.*)", RegexOptions.Compiled);
            public void Dispose()
            {
            }
            public void Init(HttpApplication application)
            {
                application.BeginRequest += this.BeginRequest;
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
                Match match = _pathRegex.Match(path);
                if (match.Success)
                {
                    string cultureName = match.Groups[1].Value;
                    if (_supportedCultures.Contains(cultureName))
                    {
                        path = match.Groups[2].Value;
                        return cultureName;
                    }
                }
                return null;
            }
        }
    }
