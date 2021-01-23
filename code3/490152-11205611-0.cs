    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            IUpdatable wrapper = new AWrapper(a);
            wrapper.Update(); // prints A.Update
        }
    }
