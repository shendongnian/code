    public class PerformanceMonitorModule : IHttpModule
    {
        public void Dispose() { /* Nothing to do */ }
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += delegate(object sender, EventArgs e)
            {
                HttpContext requestContext = ((HttpApplication)sender).Context;
                Stopwatch timer = new Stopwatch();
                requestContext.Items["Timer"] = timer;
                timer.Start();
            };
            context.PostRequestHandlerExecute += delegate(object sender, EventArgs e)
            {
                HttpContext requestContext = ((HttpApplication)sender).Context;
                Stopwatch timer = (Stopwatch)requestContext.Items["Timer"];
                timer.Stop();
                if (requestContext.Response.ContentType == "text/html")
                {
                    double seconds = (double)timer.ElapsedTicks / Stopwatch.Frequency;
                    string result =
                    string.Format("{0:F4} sec ({1:F0} req/sec)", seconds, 1 / seconds);
                    requestContext.Response.Write("<hr/>Time taken: " + result);
                }
            };
        }
    }
