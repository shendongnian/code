        class TestableTestMe : TestMe
        {
            private readonly ISomething something;
            TestableTestMe(ISomething testSpecific)
            {
                something  = testSpecific;
            }
            
            public void DoSomething()
            {
                ISomething s = SomethingFactory();
                int i = s.Run();
                //do things with i that I want to test
            }
            protected override ISomething SomethingFactory()
            {
                return something;
            }
        }
