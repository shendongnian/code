    public abstract class Job
    {
        protected Job()
        {
            Run();
        }
        protected abstract void Execute();
        protected abstract TimeSpan Interval { get; }
        private void Callback(string key, object value, CacheItemRemovedReason reason)
        {
            if (reason == CacheItemRemovedReason.Expired)
            {
                Execute();
                Run();
            }
        }
        protected void Run()
        {
            HttpRuntime.Cache.Add(GetType().ToString(), this, null, 
                Cache.NoAbsoluteExpiration, Interval, CacheItemPriority.Normal, Callback);
        }
    }
    Here is the implementation
    public class EmailJob : Job
    {
        protected override void Execute()
        {
            // TODO: send email to whole users that are registered 
        }
        protected override TimeSpan Interval
        {
            get { return new TimeSpan(0, 10, 0); }
        }
    }
