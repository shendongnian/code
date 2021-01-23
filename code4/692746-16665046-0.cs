    public class Foo
    {
        public object Locker = new object();
    }
    public class Bar
    {
        public void DoStuff()
        {
            var foo = new Foo();
            lock(foo.Locker)
            {
                // doing something here
            }
        }
    }
