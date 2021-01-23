    public class RewritingModule : IHttpModule
        {
            /// <summary>
            /// Инициализация
            /// </summary>
            /// <param name="application"></param>
            public void Init(HttpApplication application)
            {
                application.BeginRequest += ApplicationBeginRequest;
            }
    
            private static void ApplicationBeginRequest(object sender, EventArgs e)
            {
                var _httpContext = HttpContext.Current;
    
                foreach (KeyValuePair<string, string> item in DictionaryRewrites)
                {
                    var currentUrl = _httpContext.Request.RawUrl;
                    string itemKey = item.Key;
                    
                    if (currentUrl.Equals(itemKey, StringComparison.OrdinalIgnoreCase))
                    {
                        Process301Redirect(_httpContext, item.Value);
                        break;
                    }
                }
    
            }
    
            private static Dictionary<string, string> DictionaryRewrites = new Dictionary<string, string>() 
            { 
                { "/Services/Pavilions/Item.aspx?ItemID=5", "/exhibitions/pavillions/3/hall4" },
                { "/Services/ConferenceHalls/Item.aspx?ItemID=10127", "/conferences/conferencehalls/1/conferencehall1" }
    
            };
    
            /// <summary>
            /// 301 Redirect
            /// </summary>
            /// <param name="context"></param>
            /// <param name="toRedirect"></param>
            private static void Process301Redirect(HttpContext context, string toRedirect)
            {
                var _localizationSettings = EngineContext.Current.Resolve<LocalizationSettings>();
                var _workContext = EngineContext.Current.Resolve<IWorkContext>();
                var _httpContext = HttpContext.Current;
                var _webHelper = EngineContext.Current.Resolve<IWebHelper>();
                string applicationPath = _httpContext.Request.ApplicationPath;
                
                if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
                {
                    toRedirect = toRedirect.AddLanguageSeoCodeToRawUrl(applicationPath, _workContext.WorkingLanguage);
                }
                
                string str = _webHelper.GetApplicationLocation() + toRedirect;
                context.Response.AddHeader("Location", str);
                context.Response.Status = "301 Moved Permanently";
            }
    
            public void Dispose()
            {
                //clean-up code here.
            }
        }
