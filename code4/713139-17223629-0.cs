    public class ExampleService : ServiceBase
    {
        private static void Main()
        {
            ServiceBase.Run(new[] { new ExampleService() });
        }
        public ExampleService()
        {
            // Name the Service
            ServiceName = "Example Service";
        }
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
           // Does nothing
        }
        protected override void OnStop()
        {
            base.OnStop();
        }
    }
