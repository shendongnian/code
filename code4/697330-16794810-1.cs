    public class HelloWorldService: Service
    {
        public static GlobalState GlobalState = new GlobalState { ... };
        public string Get(HelloWorld request)
        {
            return GlobalState.SomeOtherClassInstance;
        }
    }
