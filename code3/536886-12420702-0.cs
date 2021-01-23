    class Test
    {
        //Index i is declared as static so that both the threads have only one copy
        static int i;
        static AutoResetEvent parentEvent = new AutoResetEvent(true);
        static AutoResetEvent childEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Thread t = new Thread(WriteY);
            i = 0;
            //Start thread Y
            t.Start();
            // Print X on the main thread
            parentEvent.WaitOne();
            while (i < 100)
            {                
                if (i % 10 == 0)
                {
                    childEvent.Set();
                    parentEvent.WaitOne();
                }
                Console.Write(i + ":Y ");
                i++;
            }
            t.Join();
        }
        static void WriteY()
        {
            childEvent.WaitOne();
            while (i < 100)
            {
                if (i % 10 == 0)
                {
                    parentEvent.Set();
                    childEvent.WaitOne();
                }
                Console.Write(i + ":X ");
                i++;
            }
        }
    }
