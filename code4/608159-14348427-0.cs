    public class FooService : IService<FooRequest>
    {
        public ILog { get; set; }
    
        public object Execute(FooRequest request)
        {
            Log.Info("Received request: " + request.Dump());
            return new FooResponse();
        }
    }
