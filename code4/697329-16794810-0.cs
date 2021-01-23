    public class HelloWorldService: Service
    {
        public GlobalState GlobalState { get; set; }
        public string Get(HelloWorld request)
        {
            return GlobalState.SomeOtherClassInstance;
        }
    }
