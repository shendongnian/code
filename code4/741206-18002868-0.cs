            if (testThread.IsAlive)
            {
                testThread.Abort();
                testThread.Join();
            }
            Console.WriteLine("main thread after abort call " + DateTime.Now.ToShortTimeString());
