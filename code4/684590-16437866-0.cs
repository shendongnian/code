    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            Func<string> doSomething = container.DoSomething;
            Delegate d = doSomething;
            // This will be the container, but you need to cast.
            var c = (Container)d.Target;
            Console.Read();
        }
    }
    class Container
    {
        public string DoSomething()
        {
            return "";
        }
    }
