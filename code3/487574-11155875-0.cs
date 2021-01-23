    public class MeasureModule : IHttpModule
    {
        private static readonly ReaderWriterLockSlim _gateway = new ReaderWriterLockSlim();
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) =>
            {
                var app = (sender as HttpApplication);
                var watch = Stopwatch.StartNew();
                app.Context.Items["watch"] = watch;
            };
            context.EndRequest += (sender, e) =>
            {
                var app = (sender as HttpApplication);
                var watch = app.Context.Items["watch"] as Stopwatch;
                watch.Stop();
                var url = app.Context.Request.Url.AbsoluteUri;
                var message = string.Format("url: {0}, time: {1}ms", url, watch.ElapsedMilliseconds);
                var log = HostingEnvironment.MapPath("~/log.txt");
                _gateway.EnterWriteLock();
                try
                {
                    File.AppendAllLines(log, new[] { message });
                }
                finally
                {
                    _gateway.ExitWriteLock();
                }
            };
        }
    }
