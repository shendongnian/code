    using System;
    using System.Threading;
    namespace Demo
    {
        class Program
        {
            void run()
            {
                Console.WriteLine("Started at " + DateTime.Now);
                RunTimedAction(action, TimeSpan.FromSeconds(10));
                Console.WriteLine("Stopped at " + DateTime.Now);
            }
            private void action(CancellationToken cancel)
            {
                int i;
                for (i = 0; i < 1000000; ++i)
                {
                    if (cancel.IsCancellationRequested)
                        break;
                    Thread.Sleep(10); // Simulate work.
                }
                Console.WriteLine("action() reached " + i);
            }
            public static void RunTimedAction(Action<CancellationToken> action, TimeSpan timeout)
            {
                using (var cancellationTokenSource = new CancellationTokenSource(timeout))
                    action(cancellationTokenSource.Token);
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
