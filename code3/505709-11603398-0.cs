    public class MockFoo : IFoo
    {
        private readonly Foo foo = new Foo();
        private bool doSomethingWasCalled;
        public void DoSomething()
        {
            doSomethingWasCalled = true;
            foo.DoSomething();
        }
    }
