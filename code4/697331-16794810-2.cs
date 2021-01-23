    public class HelloWorldService: Service
    {
        public string Get(HelloWorld request)
        {
            return GlobalState.Instance.SomeOtherClassInstance;
        }
    }
