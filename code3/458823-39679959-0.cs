    using Nancy;
    namespace test2
    {
        public class MainModule : NancyModule
        {
            public MainModule() {
                Get["/"] = parameters => "Hello World";
            }
        }
    }
