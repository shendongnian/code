    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("Test Console", typeof(AppHost).Assembly) { }
        public override void Configure(Funq.Container container)
        {
            CatchAllHandlers.Add(StaticFileHandler.Factory);
        }
    }
