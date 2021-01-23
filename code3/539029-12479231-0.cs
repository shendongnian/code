            Console.WriteLine("Main New Thread : {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            new System.Threading.Thread(() =>
            {
                Console.WriteLine("Inside New Thread : {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            }).Start();
            Console.WriteLine("Main New Thread : {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
