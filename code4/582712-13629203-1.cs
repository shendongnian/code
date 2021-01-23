    interface ISomeObject { }
    class SomeObjectA : ISomeObject { }
    class SomeObjectB : ISomeObject { }
    interface ISomething<out T> where T : ISomeObject
    {
        T GetObject();
    }
    class SomethingA : ISomething<SomeObjectA>
    {
        public SomeObjectA GetObject() { return new SomeObjectA(); }
    }
    class SomethingB : ISomething<SomeObjectB>
    {
        public SomeObjectB GetObject() { return new SomeObjectB(); }
    }
    class SomeContainer
    {
        private ISomething<ISomeObject> Something;
        public void SetSomething<T>(ISomething<T> s) where T : ISomeObject
        {
            Something = (ISomething<ISomeObject>)s;
        }
    }
    class TestContainerSomething
    {
        static public void Test()
        {
            SomeContainer Container = new SomeContainer();
            Container.SetSomething<SomeObjectA>(new SomethingA());
        }
    }
