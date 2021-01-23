    public class CultureModule : IHttpModule
    {
        private HttpApplication _httpApplication;
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            _httpApplication = context;
            context.BeginRequest += new EventHandler(CultureVariation);
        }
        void CultureVariation(object sender, EventArgs e)
        {
            var HttpHost = _httpApplication.Request.ServerVariables["HTTP_HOST"];
            var _hostname = (HttpHost.Split(':').Length > 1) ? HttpHost.Substring(0, HttpHost.IndexOf(':')) : HttpHost;
            var allowedHostnames = ConfigurationManager.AppSettings["hostnames"].ToLower().Split(',');
            foreach (var hostname in allowedHostnames)
            {
                if (hostname.StartsWith(_hostname.ToLower()))
                {
                    var lang = hostname.Split('|').Last();
                    if (lang == "en") lang = "uk";
                    // Updates the cultures for the dynamic language
                    var ci = new CultureInfo(lang);
                    System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                }
            }
        }
    }
