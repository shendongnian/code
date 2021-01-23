    using System;
    using System.Threading;
    namespace AsyncFiber
    {
        class Program
        {
            public event EventHandler<int> ClientEventReceived;
            public event EventHandler<int> MessageProcessed;
            static void Main(string[] args)
            {
                Program p = new Program();
                p.ClientEventReceived += p.p_ClientEventReceived;
                p.MessageProcessed += p.p_MessageProcessed;
                for (int i = 0; i < 5; i++)
                    new Thread(new ThreadStart(p.target)).Start();
            }
            private void p_MessageProcessed(object sender, int e)
            {
                PrintHelper("C->" + e);
            }
            private void p_ClientEventReceived(object sender, int e)
            {
                MessageProcessed(sender, e);
            }
            void target()
            {
                while (true)
                {
                    var data = new Random().Next();
                    Console.WriteLine("P->" + data);
                    ClientEventReceived(Thread.CurrentThread.Name, data);
                }
            }
            void PrintHelper(string message)
            {
                for (int i = 0; i < Thread.CurrentThread.ManagedThreadId; i++)
                    Console.Write("  ");
                Console.Write(message);
                Console.WriteLine();
            }
        }
    }
