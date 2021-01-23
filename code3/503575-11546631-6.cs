        public class ValuesController: ApiController
        {
            public MyViewModel Foo()
            {
                return new MyViewModel
                {
                    Foo = 123,
                    Bar = "abc"
                };
            }
        }
