    public class Test : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(onBeginRequest);
        }
        public void onBeginRequest(object sender, EventArgs e)
        {
            HttpContext context = (sender as HttpApplication).Context;
            if( context == nul ) { return; }
            if (context.Request.RawUrl.Contains("test-handler.ext"))
            {
                Logger.SysLog("onBeginRequest");
                TestRead(context);
            }
        }
        // Read the stream
        private static void TestRead(HttpContext context)
        {
            using (StreamReader reader = new StreamReader(context.Request.GetBufferlessInputStream()))
            {
                Logger.SysLog("Start Read");
                reader.ReadToEnd();
                Logger.SysLog("Read Completed");
            }
        }
    }
