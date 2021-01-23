        public class ValuesController : ApiController
        {
            private readonly IFoo _foo;
            public ValuesController(IFoo foo)
            {
                _foo = foo;
            }
            public string Get()
            {
                return _foo.GetBar();
            }
        }
