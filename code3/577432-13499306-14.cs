    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(NewRelicIgnoreTransactionOwinModule));
            app.MapHubs();
        }
    }
