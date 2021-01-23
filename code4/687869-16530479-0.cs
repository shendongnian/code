    class Program
    {
        static CountdownEvent CountDown = new CountdownEvent(4);
        static void Main()
        {
            new Thread(() => SaySomething("I am Thread one.")).Start();
            new Thread(() => SaySomething("I am thread two.")).Start();
            new Thread(() => SaySomethingElse("Hello From a different Thread")).Start();
            new Thread(() => SaySomething("I am Thread Three.")).Start();
            CountDown.Wait();
            Console.WriteLine("Done!");
            Console.Read();
        }
        static void SaySomething(string Something)
        {
            Thread.Sleep(1000);
            Console.WriteLine(Something);
            CountDown.Signal();
        }
        static void SaySomethingElse(string SomethingElse)
        {
            Thread.Sleep(1000);
            Console.WriteLine(SomethingElse);
            CountDown.Signal();
        }
    }
