    using System;
    using System.Threading;
    
    class Test
    {
        static void Main()
        {
            Console.TreatControlCAsInput = false;
            Console.CancelKeyPress += (sender, args) => {
                // We want to keep going...
                args.Cancel = true;
                Console.WriteLine("Handler called");
            };
            Console.WriteLine("Go for it!");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
    }
