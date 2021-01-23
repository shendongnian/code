    class Program
    {
        static void Main(string[] args)
        {
           test t = new test();
           Task.Run(async () => await t.Go());
        }
    }
