    abstract class StartUpBase
    {
        public abstract void Start();
        protected void StartApplication<T>(ILoggingContext ctx, IEnumerable<T> enumerableWork)
        {
            Parallel.ForEach(enumerableWork, iter =>
                {
                    // this code can refer to ctx e.g.
                    ctx.Log(message);
                });
        }
    }
    internal class StartupApplication1<T> : StartUpBase
    {
        // setup of this is elsewhere...
        private IEnumerable<T> _enumerableWork;
        public override void Start()
        {
            ILoggingContext ctx = Kernel.Bind<ILoggingContext>()
                .To<Application1LoggingContext>().InThreadScope();
            StartApplication(ctx, _enumerableWork);
        }
    }
