        class TestMe
        {
            private readonly ISomething something;
            TestMe() : this(new RealSomething()
            {
            }
            TestMe(ISomething sth)
            {
                something = sth;
            }
            public void DoSomething()
            {
                ISomething s = SomethingFactory();
                int i = s.Run();
                //do things with i that I want to test
            }
            private ISomething SomethingFactory()
            {
                return new Something();
            }
        }
