    abstract class BaseThingy
    {
    }
    class Thingy1 : BaseThingy
    {
        public void DoSomething()
        {
        }
    }
    class Thingy2 : BaseThingy
    {
        public void DoSomethingElse()
        {
        }
    }
    class Foo
    {
        static T GetItem<T>() where T : BaseThingy
        {
            //Won't compile, Thingy1, while deriving from BaseThingy
            //Could not be the same type of T, derive from it or have
            //An implicit cast operator to T.
            return new Thingy1();
        }
        static void Bar()
        {
            var result = GetItem<Thingy2>();
            //But your method is returning a Thingy1,
            //which doesn't have the following method
            result.DoSomethingElse();
        }
    }
