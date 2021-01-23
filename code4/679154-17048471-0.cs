    public class MvcApplication : System.Web.HttpApplication {    
        protected void Application_BeginRequest() {
            var context = this.Context;
            FirstTimeInitializer.Init(context);
        }
        private static class FirstTimeInitializer {
            private static bool s_IsInitialized = false;
            private static Object s_SyncRoot = new Object();
            public static void Init(HttpContext context) {
                if (s_IsInitialized) {
                    return;
                }
                lock (s_SyncRoot) {
                    if (s_IsInitialized) {
                        return;
                    }
                    // bootstrap
                    s_IsInitialized = true;
                }
            }
        }
    }
