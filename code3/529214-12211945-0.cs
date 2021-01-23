    public partial class App : Application
    {
        static App()
        {
            // First, we set up the internal proxy
            SetupInternalProxy();
            // The we set up the awesomium engine
            SetupBrowser();
        }
        private static void SetupInternalProxy()
        {
            // My requirement is to get response content, so I use this event.
            // You may use other handlers if you have to tamper data.
            FiddlerApplication.AfterSessionComplete += FiddlerApplication_AfterSessionComplete;
            FiddlerApplication.Log.OnLogString += (o, s) => Debug.WriteLine(s);
            FiddlerCoreStartupFlags oFCSF = FiddlerCoreStartupFlags.Default;
            //this line is important as it will avoid changing the proxy for the whole system.
            oFCSF = (oFCSF & ~FiddlerCoreStartupFlags.RegisterAsSystemProxy);
            FiddlerApplication.Startup(0, oFCSF);
        }
        private static void SetupBrowser()
        {
            // We may be a new window in the same process.
            if (!WebCore.IsRunning)
            {
                // Setup WebCore with plugins enabled.
                WebCoreConfig config = new WebCoreConfig
                {
                    // Here we plug the internal proxy to the awesomium engine
                    ProxyServer = "http://127.0.0.1:" + FiddlerApplication.oProxy.ListenPort.ToString(),
                    // Adapt others options related to your needs
                    EnablePlugins = true,
                    SaveCacheAndCookies = true,
                    UserDataPath = Environment.ExpandEnvironmentVariables(@"%APPDATA%\MyApp"),
                };
                WebCore.Initialize(config);
            }
            else
            {
                throw new InvalidOperationException("WebCore should be already running");
            }
        }
        // Here is the handler where I intercept the response
        private static void FiddlerApplication_AfterSessionComplete(Session oSession)
        {
            // Send to business objects
            DoSomethingWith(
                oSession.PathAndQuery,
                oSession.ResponseBody,
                oSession["Response", "Content-Type"]
                );
        }
    }
    
