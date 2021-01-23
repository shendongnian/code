    class Program
    {
        static void Main(string[] args)
        {
            var testAction = test();
            testAction("it works");
            // or textAction.Invoke("it works");
            Console.ReadLine();
        }
        // Don't pass a string here - the Action<string> handles that for you..
        static Action<string> test()
        {
            return (x) => Console.WriteLine(x);
        }
    }
